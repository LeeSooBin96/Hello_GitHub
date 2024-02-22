#include "serverbase.h"

//(������)���� ���̺귯�� �ʱ�ȭ �� ���� ���� -- ���� ���� �ʱ�ȭ
ServerBase::ServerBase(const char* port)
{
    if(WSAStartup(MAKEWORD(2,2),&wsaData)!=0)
    {
        ErrorHandling("WSAStartup() error!"); //���� ���̺귯�� ����ü �ʱ�ȭ ����
        return;
    }
    servSock=socket(PF_INET,SOCK_STREAM,0); //TCP ���� ����
    //�ּ� ���� �ʱ�ȭ
    memset(&servAdr,0,sizeof(servAdr));
    servAdr.sin_family=AF_INET; //IPv4
    servAdr.sin_addr.s_addr=htonl(INADDR_ANY); //ȣ��Ʈ �ּ� ���� 
    servAdr.sin_port=htons(atoi(port));
    //�ּ� �Ҵ�
    if(bind(servSock,(SOCKADDR*)&servAdr,sizeof(servAdr))==SOCKET_ERROR)
    {
        ErrorHandling("bind() error");
    }
}
//(�Ҹ���) ���� ����
ServerBase::~ServerBase()
{
    closesocket(servSock); //���� ���� ����
    WSACleanup(); //���� ���̺귯�� ����
}

//���� ����(��� ť ũ��)
void ServerBase::openServer(int waitnum)
{
    if(listen(servSock,waitnum)==SOCKET_ERROR) //Ŭ���̾�Ʈ ���� ���
    {
        ErrorHandling("listen() error");
    }
    else
    {
        std::cout<<"���� ���� \n";
    }
}
//���� �޽��� ��� �� ����
void ServerBase::ErrorHandling(std::string msg)
{
    std::cerr<<msg<<std::endl;
    exit(1);
}