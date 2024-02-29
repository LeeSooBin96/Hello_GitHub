#include "clientbase.h"

//(������) ���� ������, ��Ʈ��ȣ ���� ���� --������ ����
ClientBase::ClientBase(const char* ip,const char* port)
{
    if(WSAStartup(MAKEWORD(2,2),&wsaData)!=0) //���� ���̺귯�� ����ü �ʱ�ȭ
    {
        ErrorHandling("WSAStartup() error!");
    }
    sock=socket(PF_INET,SOCK_STREAM,0); //TCP ���� ����
    //�ּ� ���� �ʱ�ȭ
    memset(&servAdr,0,sizeof(servAdr));
    servAdr.sin_family=AF_INET;
    servAdr.sin_addr.s_addr=inet_addr(ip); //�Էµ� �����Ƿ� ����
    servAdr.sin_port=htons(atoi(port)); //�Էµ� ��Ʈ��ȣ�� ����
    //������ ����
    if(connect(sock,(SOCKADDR*)&servAdr,sizeof(servAdr))==SOCKET_ERROR)
    {
        ErrorHandling("connect() error");
    }
    else
    {
        std::cout<<"������ ����Ǿ����ϴ�. \n";
    }
}
ClientBase::~ClientBase()
{
    closesocket(sock);
    WSACleanup();
}
//���� �޽��� ��� �� ����
void ClientBase::ErrorHandling(std::string msg)
{
    std::cerr<<msg<<std::endl;
    exit(1);
}