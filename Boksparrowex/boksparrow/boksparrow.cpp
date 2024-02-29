//복스패로우 클라이언트
#include <string>
// #include <vector>

#include "clientbase.h"

const unsigned int BUF_SIZE=1024;
const char* SERVER_IP="127.0.0.1";

// std::vector<std::string> chatroomList;

int main()
{
    char buffer[BUF_SIZE]={0}; //버퍼

    ClientBase clnt(SERVER_IP,"91016"); //서버 연결
    while(true)
    {//연결되면 닉네임 입력 받기
        std::cout<<"닉네임을 입력하세요: (20자 이하)";
        std::string nick;
        std::getline(std::cin,nick);
        while(nick.size()>20)
        {
            std::cout<<"입력된 닉네임: "<<nick; //확인용
            std::cout<<"닉네임을 다시 입력하세요: (20자 이하)";
            std::getline(std::cin,nick);
        }
        //이닉네임을 서버로 보내야함 --닉네임만 보내서는 안되고.. 코드 같이 보내자 
        //수정사항에 맞춰서
        nick="N:"+nick;
        itoa(nick.size(),buffer,10);
        std::string msg=buffer;
        msg.append(nick);
        send(clnt.sock,msg.c_str(),msg.size(),0);
        //닉네임 중복검사 결과 보내줄거임 중복이면 다시 입력하게
        memset(buffer,0,BUF_SIZE);
        recv(clnt.sock,buffer,2,0);
        if(!strncmp(buffer,"S",2)) break;
        else
        {
            std::cout<<"중복된 닉네임입니다. \n";    
        }
    }

    //서버에서 채팅방정보 받아와서 클라이언트에게 보여줘야해
    send(clnt.sock,"2C:",3,0); //채팅방 정보 요청



    int recvLen;
    recvLen=recv(clnt.sock,buffer,BUF_SIZE,0);
//     std::string roomNum=strtok(buffer,"@"); //채팅방 개수
//     for(int i=0;i<stoi(roomNum);i++)
//     {
//         //채팅방 이름 출력
//         std::cout<<strtok(NULL,"@")<<" ";
//         //채팅방 코드 저장해둬야함 --그럼 여기 안해도됨
//         // chatroomList.push_back(strtok(NULL,"@"));
//         //접속 인원
//         std::cout<<"접속: "<<strtok(NULL,"@")<<std::endl; 
//     }
//     std::cout<<"채팅방을 선택하세요 >";
//     char input[2]={0};
//     std::cin>>input;
//     send(clnt.sock,input,sizeof(input),0);
//     //채팅방 코드를 서버에 보내면 
//     //서버로부터 새로운 포트번호 부여받을것
//     memset(buffer,0,BUF_SIZE);
//     recv(clnt.sock,buffer,5,0);
//     std::cout<<buffer<<std::endl;
//     buffer[5]=0;
//     //메인 서버 연결 종료
//     send(clnt.sock,"THX",4,0);
//     // clnt.~ClientBase();
//     // std::cout<<"메인서버 연결 종료 \n";
//     // Sleep(10000);
//     //새로운 포트번호로 접속하기 --오류난다...
//     // ClientBase clntChat(SERVER_IP,buffer);

    return 0;
}
