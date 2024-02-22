#include "chatserver.h"

//채팅 서버 메인
ChatServer::ChatServer(const char* port)
: ServerBase(port)
{
    std::cout<<"전달된 포트번호: "<<port<<std::endl;
    openServer();

    SOCKET clntSock;
    SOCKADDR_IN clntAdr;
    int clntAdrSz=sizeof(clntAdr);

    accept(clntSock,(SOCKADDR*)&clntAdr,&clntAdrSz);

} 