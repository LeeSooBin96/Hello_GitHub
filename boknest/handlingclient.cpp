#include "handlingclient.h"

//(������)Ŭ���̾�Ʈ ���� ��û�� �޾ƾ���
HandlingClient::HandlingClient()
{
    int clntAdrSz; //Ŭ���̾�Ʈ �ּ� ũ�� ���� ����
    SOCKET clntSock; //Ŭ���̾�Ʈ ����

    serv = new ServerBase("91016"); //���� ����
    serv->openServer(10); //���� ���� ����
    while(1)
    {
        clntSock=accept(serv->servSock,(SOCKADDR*)&clntSock,&clntAdrSz);

        //���� ���� Ŭ���̾�Ʈ���� ������ �� �ֵ��� �ؾ��ϴ� �۾��� �غ��� --Ŭ���̾�Ʈ Ŭ������ �и� �غ��� --�Ϸ�
        seperateClient(clntSock);
        //���� �Ϸ� �׷� ä�ù��� �����ؾ��ϴµ� �����ѱ� �ƴ� ������ �����ϰ� �ұ�
        //�ϴ� read�Լ� ������� �Ҵ� ��Ű�� --Ŭ���̾�Ʈ ��û�� ó���Ұ�
        HANDLE thread; //������ �ڵ�
        thread=(HANDLE)_beginthreadex(NULL,0,&readMSG,(void*)&clntSock,0,NULL);
    }
}
//(�Ҹ���)Ŭ���̾�Ʈ ������ ���� ����
HandlingClient::~HandlingClient()
{
    for(auto mem: clntList)
    {
        closesocket(mem.clntSock); //����� ���ϵ� ��� ����
    }
}
//����� Ŭ���̾�Ʈ ������ ���� �����ϱ�
void HandlingClient::seperateClient(SOCKET sock)
{
    char name[21];
    int len;
    len=recv(sock,name,20,0);
    name[len]=0;
    std::cout<<name<<"���� �����ϼ̽��ϴ�. \n";
    
    clntInfo clnt;
    clnt.clntSock=sock;
    clnt.nick=name;
    std::cout<<"��ϵ� ���� �̸�: "<<clnt.nick<<" ��ȣ: "<<clnt.clntSock<<std::endl;
    clntList.push_back(clnt);
}
//�� Ŭ���̾�Ʈ�κ��� ��û ���� --������� �����
unsigned WINAPI HandlingClient::readMSG(void* arg)
{
    SOCKET recvSock = *((SOCKET*)arg); //���޵� ���� ����
}