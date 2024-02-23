//�����зο� ����(����)
#include <vector>
#include <string>
#include <process.h>

#include "serverbase.h"

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
//     bool state=false;
};

std::vector<clntInfo> clntList; //�г���-���� ���� ����ü �迭
std::vector<chatroomInfo> cRoomList; //ä�ù� ����Ʈ


//Ŭ���̾�Ʈ ���� ������ ����Ǵ� ���μ���
unsigned WINAPI processClient(void* arg);


int main()
{
    // �⺻ ä�ù� ����
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
    clntInfo clnt; //Ŭ���̾�Ʈ ���� ������ ����ü ����

    //���� ��û�� �´� ó���� �ϵ��� ���Ż��� ����
    std::string len, msg;
    char buffer[BUF_SIZE]={0};
    int recvLen, strLen;
    while(recv(clntSock,buffer,BUF_SIZE,0)>0) //receive ��Ʈ���� ������ ������(Ȥ�� ���� ����)
    {
        //�ʱ�ȭ �Ұ�
        msg.clear();
        std::cout<<"Ŭ���̾�Ʈ�κ��� "<<buffer<<std::endl;
        msg.append(buffer); memset(buffer,0,BUF_SIZE);
        recvLen=msg.size(); //���� ���� �޽��� ����
        //���� �Բ� �޾Ƽ� �Ҵ� ������ ���� ���� 
        strLen = std::stoi(msg); //���� �޾ƾ� �Ǵ� �޽��� ����
        itoa(strLen,buffer,10);len=buffer; //���� ���ŵ� �޽��� ������ ���� üũ
        
        std::cout<<"���� �޽��� ����: "<<recvLen<<std::endl;
        std::cout<<"���޵� �޽��� ����: "<<strLen+len.size()<<std::endl;
        while(recvLen!=strLen+len.size()) //���� ���� �ȵǾ�����
        {
            memset(buffer,0,BUF_SIZE);
            int tmpLen=recv(clntSock,buffer,BUF_SIZE,0);
            msg.append(buffer);
            recvLen+=tmpLen;
        }//�� �б�
        msg=msg.substr(len.size(),strLen); //�޽��� ���� ���ڿ����� ����
        
        //��� �ڵ� �˻��Ͽ� ��û�� �´� ó���� ��
        if(msg.substr(0,msg.find(':'))=="N")
        {
            // std::cout<<msg.substr(msg.find(':')+1,strLen-2); //�Է��� �г���
            
            clnt.clntSock=clntSock;
            clnt.nick=msg.substr(msg.find(':')+1,strLen-2);
            bool ck=true;
            for(auto mem: clntList)
            {
                if(mem.nick==clnt.nick) //�г��� �ߺ� �˻�
                {
                    send(clntSock,"F",2,0);
                    ck=false;
                }
            }
            if(ck) //�г��� �ߺ��˻� ���
            {
                send(clntSock,"S",2,0);
                clntList.push_back(clnt); //�г��� �ߺ��˻� �� �� �־����
                std::cout<<"������ ���� : "<<clnt.nick<<std::endl;
                //ä�ù� ���� ��������
                //�ٷ� ������ ���� ���� ����
            }
        }
        else if(msg.substr(0,msg.find(':'))=="C")
        {
            std::cout<<"ä�ù� ���� ��û�� \n";
        }
        memset(buffer,0,BUF_SIZE); //���� �ʱ�ȭ
    }
//     //ä�ù� ������ �ڵ带 ������ ��.
//     std::string chatroomInfo;
//     char buf[BUF_SIZE]={0};
//     itoa(cRoomList.size(),buf,10);
//     chatroomInfo.append(buf); //ä�ù� ���� ����
//     for(int i=0;i<cRoomList.size();i++)
//     {
//         //ä�ù� �̸�, ä�ù� �ڵ�(�̰͵� �Ⱥ����� �ǰ�), ä�ù� �����ο� ��������
//         chatroomInfo.append("@"+cRoomList[i].title+"@");//+cRoomList[i].code+"@");
//         itoa(cRoomList[i].conUser.size(),buf,10);
//         chatroomInfo.append(buf);
//     }
//     send(clntSock,chatroomInfo.c_str(),chatroomInfo.size(),0);
//     //���߿� �ٸ� ���� ���� ������ �Բ� ������ �� �ֵ��� �ؾ���
//     //ä�ù� ������ �ʿ��Ѱ�: ä�ù� �̸�, �ڵ�, ������ ����, ȭ��Ʈ����Ʈ(NULL�� ����ä�ù�)
//     //�� ä�ù溰 �����带 ������ �ƴϸ� ��Ʈ�� �ٸ��� ������ ���� ����
//     //������� �ϰԵǸ� �� ä�ù溰 �۽� ���� �����带 �θ�� --�̰Ÿ��� ����ڵ� �ռ����� ��ȭ�ϵ���
//     //������ �ϰԵǸ� Ŭ���� �ϳ� ���� ä�� ���� Ŭ������ Ʋ�� ¥�� ��Ʈ��ȣ �ѱ���...��...
//     //ä�ù��� ��� �����ȴٰ� �ϸ� 2�� �����̶�� 1���ε�
//     //�ĸ� ���ؼ� 2�� �غ��� ---1������ ������ �ǵ��� �غ��°ɷ�
//     //�켱 ���õ� ä�ù� �ڵ� ��� ����
//     memset(buf,0,BUF_SIZE);
//     recv(clntSock,buf,BUF_SIZE,0); //ä�ù� �ڵ� �ޱ� --�ε����� �ٲ���
//     int portNum=91016+std::stoi(cRoomList[std::stoi(buf)].code);
//     char portNumString[5];
//     itoa(portNum,portNumString,10);
//     //���ο� ��Ʈ��ȣ �����ϰ�
//     send(clntSock,portNumString,5,0);
//     std::cout<<portNumString<<std::endl;
//     //Ȯ�θ޽��� ������ ���� ���� ����
//     shutdown(clntSock,2);
//     recv(clntSock,buf,BUF_SIZE,0);
//     std::cout<<"Ȯ�θ޽���: "<<buf<<std::endl;
//     // closesocket(clntSock);
//     //ä�ü��� ���� --���µ� ������ ...�� ���� �ȵǰ� �ؾ��ϳ�? �׷����ҵ� ���ε� ���� �߰ڴ�
//     //�ѹ� ���µǸ� ���� ���¿��� ��� ������ ���� --���� ����� �غ����ҵ�
//     // ChatServer serv(portNumString);
    std::cout<<clnt.nick<<"�� ���� ���� \n";
    
}