//복스패로우 클라이언트
#include <string>
#include <vector>

#include "clientbase.h"

const unsigned int BUF_SIZE=1024;

std::vector<std::string> chatroomList;

int main()
{
    ClientBase clnt("127.0.0.1","91016");
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
    char buffer[BUF_SIZE]={0}; //버퍼
    int recvLen;
    recvLen=recv(clnt.sock,buffer,BUF_SIZE,0);
    std::string roomNum=strtok(buffer,"@"); //채팅방 개수
    for(int i=0;i<stoi(roomNum);i++)
    {
        //채팅방 이름 출력
        std::cout<<strtok(NULL,"@")<<" ";
        //채팅방 코드 저장해둬야함
        chatroomList.push_back(strtok(NULL,"@"));
        //접속 인원
        std::cout<<"접속: "<<strtok(NULL,"@")<<std::endl; 
    }
    std::cout<<"채팅방을 선택하세요 >";
    char input;
    std::cin>>input;
    // std::cout<<(int)input; //1=49

    send(clnt.sock,chatroomList[(int)input-49].c_str(),3,0);
    //채팅방 코드를 서버에 보내면 
    //어떻게 할까...?
    
    

    return 0;
}
