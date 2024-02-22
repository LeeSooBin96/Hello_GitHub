//복스패로우 둥지(서버)
#include <vector>
#include <string>
#include <process.h>

#include "serverbase.h"
#include "chatserver.h"

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
};

std::vector<clntInfo> clntList; //닉네임-소켓 연결 구조체 배열
std::vector<chatroomInfo> cRoomList; //채팅방 리스트


//클라이언트 연결 수락시 실행되는 프로세스
unsigned WINAPI processClient(void* arg);

int main()
{
    //기본 채팅방 생성
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
        //연결만 하고 메시지 수신 파트 스레드로 넘기자--성공 이제 저기서 수신받은 메시지 기준으로 처리하면됨.
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
    //우선 접속하자마자
    //접속한 클라이언트 닉네임-소켓 연결
    char name[21]={0};
    int len;
    len=recv(clntSock,name,20,0);
    name[len]=0;

    clntInfo clnt;
    clnt.clntSock=clntSock;
    clnt.nick=name;
    std::cout<<"접속한 유저 : "<<clnt.nick<<std::endl;
    clntList.push_back(clnt); //인덱스가 필요한건 아니기 때문에 여기는 임계영역 설정이 필요 없음
    //닉네임이 안겹치게 하는 부분은 필요할것같은데 --나중에 추가 우선 채팅방 만들어보자
    //채팅방 개수와 코드를 전달할 것.
    std::string chatroomInfo;
    char buf[BUF_SIZE]={0};
    itoa(cRoomList.size(),buf,10);
    chatroomInfo.append(buf); //채팅방 개수 전달
    for(int i=0;i<cRoomList.size();i++)
    {
        //채팅방 이름, 채팅방 코드, 채팅방 접속인원 보내야함
        chatroomInfo.append("@"+cRoomList[i].title+"@"+cRoomList[i].code+"@");
        itoa(cRoomList[i].conUser.size(),buf,10);
        chatroomInfo.append(buf);
    }
    send(clntSock,chatroomInfo.c_str(),chatroomInfo.size(),0);
    //나중에 다른 유저 접속 정보도 함께 전달할 수 있도록 해야함
    //채팅방 정보에 필요한것: 채팅방 이름, 코드, 접속한 유저, 화이트리스트(NULL은 오픈채팅방)
    //각 채팅방별 스레드를 돌릴까 아니면 포트를 다르게 서버를 새로 열까
    //스레드로 하게되면 각 채팅방별 송신 수신 스레드를 두면됨
    //서버로 하게되면 클래스 하나 만들어서 채팅 서버 클래스로 틀을 짜고 포트번호 넘기면됨...음...
    //채팅방이 계속 생성된다고 하면 2안 고정이라면 1안인데
    //후를 위해서 2안 해보자
    //우선 선택된 채팅방 코드 들고 오기
    memset(buf,0,BUF_SIZE);
    recv(clntSock,buf,3,0); //채팅방 코드 받기
    std::cout<<buf<<std::endl;
    int portNum=91016+std::stoi(buf);
    std::cout<<portNum<<std::endl;
    char* portNumString;
    itoa(portNum,portNumString,10);
    std::cout<<portNumString<<std::endl;

    ChatServer serv(portNumString);
}