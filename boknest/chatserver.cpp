#include "chatserver.h"

//ä�� ���� ����
ChatServer::ChatServer(const char* port)
: ServerBase(port)
{
    std::cout<<"���޵� ��Ʈ��ȣ: "<<port<<std::endl;
    openServer();

    SOCKET clntSock;
    SOCKADDR_IN clntAdr;
    int clntAdrSz=sizeof(clntAdr);

    accept(clntSock,(SOCKADDR*)&clntAdr,&clntAdrSz);

} 