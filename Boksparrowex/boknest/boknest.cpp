//복스패로우 둥지(서버)
#include <vector>
#include <string>
#include <process.h>

#include "serverbase.h"

const unsigned int BUF_SIZE=1024;

struct clntInfo //유저 소켓-닉네임 연결
{
    std::string nick;
    SOCKET clntSock;
};
struct chatroomInfo //채팅방 정보
{
    std::string title; //채팅방 이름
    std::string code; //채팅방 코드
    std::vector<std::string> whiteList; //화이트리스트
    std::vector<std::string> conUser; //접속한 유저
//     bool state=false;
};

std::vector<clntInfo> clntList; //닉네임-소켓 연결 구조체 배열
std::vector<chatroomInfo> cRoomList; //채팅방 리스트


//클라이언트 연결 수락시 실행되는 프로세스
unsigned WINAPI processClient(void* arg);


int main()
{
    // 기본 채팅방 생성
    cRoomList.push_back(chatroomInfo{"채팅방1","123",});
    cRoomList.push_back(chatroomInfo{"채팅방2","456",});
    cRoomList.push_back(chatroomInfo{"채팅방3","789",});

    ServerBase serv("91016"); //서버 초기화
    serv.openServer(); //서버 오픈
    while(true) //계속해서 클라이언트 받음
    {
        //클라이언트 연결
        SOCKET clntSock;
        SOCKADDR_IN clntAdr;
        int clntAdrSz=sizeof(clntAdr);
        clntSock=accept(serv.servSock,(SOCKADDR*)&clntAdr,&clntAdrSz);
        std::cout<<"접속한 아이피: "<<inet_ntoa(clntAdr.sin_addr)<<std::endl;
        HANDLE hthread;
        hthread=(HANDLE)_beginthreadex(NULL,0,processClient,(void*)&clntSock,0,NULL);
    }
    //아마 여기 아래는 실행되지 않을것
    //연결된 모든 클라이언트 소켓 종료
    for(auto mem: clntList)
    {
        closesocket(mem.clntSock);
    }
    
    return 0;
}
//연결된 클라이언트 처리 --각 클라이언트마다 실행됨. 
unsigned WINAPI processClient(void* arg)
{
    SOCKET clntSock=*((SOCKET*)arg); //전달된 클라이언트 소켓 저장
    clntInfo clnt; //클라이언트 정보 저장할 구조체 변수

    //들어온 요청에 맞는 처리를 하도록 수신상태 유지
    std::string len, msg;
    char buffer[BUF_SIZE]={0};
    int recvLen, strLen;
    while(recv(clntSock,buffer,BUF_SIZE,0)>0) //receive 스트림이 닫히기 전까지(혹은 연결 종료)
    {
        //초기화 할것
        msg.clear();
        std::cout<<"클라이언트로부터 "<<buffer<<std::endl;
        msg.append(buffer); memset(buffer,0,BUF_SIZE);
        recvLen=msg.size(); //수신 받은 메시지 길이
        //길이 함께 받아서 잃는 데이터 없게 하자 
        strLen = std::stoi(msg); //전달 받아야 되는 메시지 길이
        itoa(strLen,buffer,10);len=buffer; //같이 수신된 메시지 길이의 길이 체크
        
        std::cout<<"읽은 메시지 길이: "<<recvLen<<std::endl;
        std::cout<<"전달된 메시지 길이: "<<strLen+len.size()<<std::endl;
        while(recvLen!=strLen+len.size()) //전부 전달 안되었을때
        {
            memset(buffer,0,BUF_SIZE);
            int tmpLen=recv(clntSock,buffer,BUF_SIZE,0);
            msg.append(buffer);
            recvLen+=tmpLen;
        }//더 읽기
        msg=msg.substr(len.size(),strLen); //메시지 길이 문자열에서 제거
        
        //통신 코드 검사하여 요청에 맞는 처리할 것
        if(msg.substr(0,msg.find(':'))=="N")
        {
            // std::cout<<msg.substr(msg.find(':')+1,strLen-2); //입력한 닉네임
            
            clnt.clntSock=clntSock;
            clnt.nick=msg.substr(msg.find(':')+1,strLen-2);
            bool ck=true;
            for(auto mem: clntList)
            {
                if(mem.nick==clnt.nick) //닉네임 중복 검사
                {
                    send(clntSock,"F",2,0);
                    ck=false;
                }
            }
            if(ck) //닉네임 중복검사 통과
            {
                send(clntSock,"S",2,0);
                clntList.push_back(clnt); //닉네임 중복검사 한 후 넣어야함
                std::cout<<"접속한 유저 : "<<clnt.nick<<std::endl;
                //채팅방 정보 보내야함
                //바로 보내면 같이 가니 따로
            }
        }
        else if(msg.substr(0,msg.find(':'))=="C")
        {
            std::cout<<"채팅방 정보 요청함 \n";
        }
        memset(buffer,0,BUF_SIZE); //버퍼 초기화
    }
//     //채팅방 개수와 코드를 전달할 것.
//     std::string chatroomInfo;
//     char buf[BUF_SIZE]={0};
//     itoa(cRoomList.size(),buf,10);
//     chatroomInfo.append(buf); //채팅방 개수 전달
//     for(int i=0;i<cRoomList.size();i++)
//     {
//         //채팅방 이름, 채팅방 코드(이것도 안보내도 되고), 채팅방 접속인원 보내야함
//         chatroomInfo.append("@"+cRoomList[i].title+"@");//+cRoomList[i].code+"@");
//         itoa(cRoomList[i].conUser.size(),buf,10);
//         chatroomInfo.append(buf);
//     }
//     send(clntSock,chatroomInfo.c_str(),chatroomInfo.size(),0);
//     //나중에 다른 유저 접속 정보도 함께 전달할 수 있도록 해야함
//     //채팅방 정보에 필요한것: 채팅방 이름, 코드, 접속한 유저, 화이트리스트(NULL은 오픈채팅방)
//     //각 채팅방별 스레드를 돌릴까 아니면 포트를 다르게 서버를 새로 열까
//     //스레드로 하게되면 각 채팅방별 송신 수신 스레드를 두면됨 --이거말고 통신코드 앞세워서 대화하도록
//     //서버로 하게되면 클래스 하나 만들어서 채팅 서버 클래스로 틀을 짜고 포트번호 넘기면됨...음...
//     //채팅방이 계속 생성된다고 하면 2안 고정이라면 1안인데
//     //후를 위해서 2안 해보자 ---1안으로 여러개 되도록 해보는걸로
//     //우선 선택된 채팅방 코드 들고 오기
//     memset(buf,0,BUF_SIZE);
//     recv(clntSock,buf,BUF_SIZE,0); //채팅방 코드 받기 --인덱스로 바꾸자
//     int portNum=91016+std::stoi(cRoomList[std::stoi(buf)].code);
//     char portNumString[5];
//     itoa(portNum,portNumString,10);
//     //새로운 포트번호 전달하고
//     send(clntSock,portNumString,5,0);
//     std::cout<<portNumString<<std::endl;
//     //확인메시지 수신후 소켓 연결 종료
//     shutdown(clntSock,2);
//     recv(clntSock,buf,BUF_SIZE,0);
//     std::cout<<"확인메시지: "<<buf<<std::endl;
//     // closesocket(clntSock);
//     //채팅서버 오픈 --오픈된 서버면 ...또 오픈 안되게 해야하나? 그래야할듯 바인딩 오류 뜨겠다
//     //한번 오픈되면 리슨 상태에서 계속 돌도록 하자 --여긴 고민좀 해봐야할듯
//     // ChatServer serv(portNumString);
    std::cout<<clnt.nick<<"님 접속 종료 \n";
    
}