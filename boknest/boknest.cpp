//�����зο� ����(����)
#include <vector>
#include <string>
#include <process.h>

#include "serverbase.h"
#include "chatserver.h"

const unsigned int BUF_SIZE=1024;

struct clntInfo //���� ����-�г��� ����
{
    std::string nick;
    SOCKET clntSock;
};
struct chatroomInfo //ä�ù� ����
{
    std::string title; //ä�ù� �̸�
    std::string code; //ä�ù� �ڵ�
    std::vector<std::string> whiteList; //ȭ��Ʈ����Ʈ
    std::vector<std::string> conUser; //������ ����
};

std::vector<clntInfo> clntList; //�г���-���� ���� ����ü �迭
std::vector<chatroomInfo> cRoomList; //ä�ù� ����Ʈ


//Ŭ���̾�Ʈ ���� ������ ����Ǵ� ���μ���
unsigned WINAPI processClient(void* arg);

int main()
{
    //�⺻ ä�ù� ����
    cRoomList.push_back(chatroomInfo{"ä�ù�1","123",});
    cRoomList.push_back(chatroomInfo{"ä�ù�2","456",});
    cRoomList.push_back(chatroomInfo{"ä�ù�3","789",});

    ServerBase serv("91016"); //���� �ʱ�ȭ
    serv.openServer(); //���� ����
    while(true) //����ؼ� Ŭ���̾�Ʈ ����
    {
        //Ŭ���̾�Ʈ ����
        SOCKET clntSock;
        SOCKADDR_IN clntAdr;
        int clntAdrSz=sizeof(clntAdr);
        clntSock=accept(serv.servSock,(SOCKADDR*)&clntAdr,&clntAdrSz);
        std::cout<<"������ ������: "<<inet_ntoa(clntAdr.sin_addr)<<std::endl;
        //���Ḹ �ϰ� �޽��� ���� ��Ʈ ������� �ѱ���--���� ���� ���⼭ ���Ź��� �޽��� �������� ó���ϸ��.
        HANDLE hthread;
        hthread=(HANDLE)_beginthreadex(NULL,0,processClient,(void*)&clntSock,0,NULL);
    }
    //�Ƹ� ���� �Ʒ��� ������� ������
    //����� ��� Ŭ���̾�Ʈ ���� ����
    for(auto mem: clntList)
    {
        closesocket(mem.clntSock);
    }
    
    return 0;
}
//����� Ŭ���̾�Ʈ ó�� --�� Ŭ���̾�Ʈ���� �����. 
unsigned WINAPI processClient(void* arg)
{
    SOCKET clntSock=*((SOCKET*)arg); //���޵� Ŭ���̾�Ʈ ���� ����
    //�켱 �������ڸ���
    //������ Ŭ���̾�Ʈ �г���-���� ����
    char name[21]={0};
    int len;
    len=recv(clntSock,name,20,0);
    name[len]=0;

    clntInfo clnt;
    clnt.clntSock=clntSock;
    clnt.nick=name;
    std::cout<<"������ ���� : "<<clnt.nick<<std::endl;
    clntList.push_back(clnt); //�ε����� �ʿ��Ѱ� �ƴϱ� ������ ����� �Ӱ迵�� ������ �ʿ� ����
    //�г����� �Ȱ�ġ�� �ϴ� �κ��� �ʿ��ҰͰ����� --���߿� �߰� �켱 ä�ù� ������
    //ä�ù� ������ �ڵ带 ������ ��.
    std::string chatroomInfo;
    char buf[BUF_SIZE]={0};
    itoa(cRoomList.size(),buf,10);
    chatroomInfo.append(buf); //ä�ù� ���� ����
    for(int i=0;i<cRoomList.size();i++)
    {
        //ä�ù� �̸�, ä�ù� �ڵ�, ä�ù� �����ο� ��������
        chatroomInfo.append("@"+cRoomList[i].title+"@"+cRoomList[i].code+"@");
        itoa(cRoomList[i].conUser.size(),buf,10);
        chatroomInfo.append(buf);
    }
    send(clntSock,chatroomInfo.c_str(),chatroomInfo.size(),0);
    //���߿� �ٸ� ���� ���� ������ �Բ� ������ �� �ֵ��� �ؾ���
    //ä�ù� ������ �ʿ��Ѱ�: ä�ù� �̸�, �ڵ�, ������ ����, ȭ��Ʈ����Ʈ(NULL�� ����ä�ù�)
    //�� ä�ù溰 �����带 ������ �ƴϸ� ��Ʈ�� �ٸ��� ������ ���� ����
    //������� �ϰԵǸ� �� ä�ù溰 �۽� ���� �����带 �θ��
    //������ �ϰԵǸ� Ŭ���� �ϳ� ���� ä�� ���� Ŭ������ Ʋ�� ¥�� ��Ʈ��ȣ �ѱ���...��...
    //ä�ù��� ��� �����ȴٰ� �ϸ� 2�� �����̶�� 1���ε�
    //�ĸ� ���ؼ� 2�� �غ���
    //�켱 ���õ� ä�ù� �ڵ� ��� ����
    memset(buf,0,BUF_SIZE);
    recv(clntSock,buf,3,0); //ä�ù� �ڵ� �ޱ�
    std::cout<<buf<<std::endl;
    int portNum=91016+std::stoi(buf);
    std::cout<<portNum<<std::endl;
    char* portNumString;
    itoa(portNum,portNumString,10);
    std::cout<<portNumString<<std::endl;

    ChatServer serv(portNumString);
}