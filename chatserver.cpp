#include "chatserver.h"

//채팅 서버 메인
ChatServer::ChatServer(const char* port)
: ServerBase(port)
{
    // std::cout<<"전달된 포트번호: "<<port<<std::endl;
    openServer(); //채팅 서버 오픈

    SOCKET clntSock;
    SOCKADDR_IN clntAdr;
    int clntAdrSz=sizeof(clntAdr);
    //여기부터는 스레드로 넘길부분
    accept(clntSock,(SOCKADDR*)&clntAdr,&clntAdrSz);

} 