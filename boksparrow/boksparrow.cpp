#include <string>

#include "clientbase.h"

int main()
{
    ClientBase clnt("10.10.20.98","91016");
    //연결되면 닉네임 입력 받기
    std::cout<<"닉네임을 입력하세요: (20자 이하)";
    std::string nick;
    std::getline(std::cin,nick);
    while(nick.size()>20)
    {
        std::cout<<"입력된 닉네임: "<<nick; //확인용
        std::cout<<"닉네임을 다시 입력하세요: (20자 이하)";
        std::getline(std::cin,nick);
    }
    //이닉네임을 서버로 보내야함
    send(clnt.sock,nick.c_str(),nick.size(),0);
    //서버에서 채팅방정보 받아와서 클라이언트에게 보여줘야해
    

    char msg[30];
    recv(clnt.sock,msg,sizeof(msg),0); //임시
    std::cout<<msg;
    return 0;
}
