#include "handlingclient.h"

//(������)Ŭ���̾�Ʈ ���� ��û�� �޾ƾ���
HandlingClient::HandlingClient()
{
    int clntAdrSz; //Ŭ���̾�Ʈ �ּ� ũ�� ���� ����
    SOCKET clntSock; //Ŭ���̾�Ʈ ����
    SOCKADDR_IN clntAdr;

    serv = new ServerBase("91016"); //���� ����
    serv->openServer(10); //���� ���� ����
    while(1)
    {
        //������ ���� ���Ӹ� �ȴ�. ���߿� �����ϱ�
        clntSock=accept(serv->servSock,(SOCKADDR*)&clntAdr,&clntAdrSz);
        std::cout<<"������ ������ : "<<inet_ntoa(clntAdr.sin_addr);
        //���� ���� Ŭ���̾�Ʈ���� ������ �� �ֵ��� �ؾ��ϴ� �۾��� �غ��� --Ŭ���̾�Ʈ Ŭ������ �и� �غ��� --�Ϸ�
        HANDLE hthread;
        hthread=(HANDLE)_beginthreadex(NULL,0,(_beginthreadex_proc_type)seperateClient,&clntSock,0,NULL);
        seperateClient(clntSock);
        //���� �Ϸ� �׷� ä�ù��� �����ؾ��ϴµ� �����ѱ� �ƴ� ������ �����ϰ� �ұ�
        
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
void HandlingClient::seperateClient(void* arg)
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
