//�����зο� Ŭ���̾�Ʈ
#include <string>
// #include <vector>

#include "clientbase.h"

const unsigned int BUF_SIZE=1024;
const char* SERVER_IP="127.0.0.1";

// std::vector<std::string> chatroomList;

int main()
{
    char buffer[BUF_SIZE]={0}; //����

    ClientBase clnt(SERVER_IP,"91016"); //���� ����
    while(true)
    {//����Ǹ� �г��� �Է� �ޱ�
        std::cout<<"�г����� �Է��ϼ���: (20�� ����)";
        std::string nick;
        std::getline(std::cin,nick);
        while(nick.size()>20)
        {
            std::cout<<"�Էµ� �г���: "<<nick; //Ȯ�ο�
            std::cout<<"�г����� �ٽ� �Է��ϼ���: (20�� ����)";
            std::getline(std::cin,nick);
        }
        //�̴г����� ������ �������� --�г��Ӹ� �������� �ȵǰ�.. �ڵ� ���� ������ 
        //�������׿� ���缭
        nick="N:"+nick;
        itoa(nick.size(),buffer,10);
        std::string msg=buffer;
        msg.append(nick);
        send(clnt.sock,msg.c_str(),msg.size(),0);
        //�г��� �ߺ��˻� ��� �����ٰ��� �ߺ��̸� �ٽ� �Է��ϰ�
        memset(buffer,0,BUF_SIZE);
        recv(clnt.sock,buffer,2,0);
        if(!strncmp(buffer,"S",2)) break;
        else
        {
            std::cout<<"�ߺ��� �г����Դϴ�. \n";    
        }
    }

    //�������� ä�ù����� �޾ƿͼ� Ŭ���̾�Ʈ���� ���������
    send(clnt.sock,"2C:",3,0); //ä�ù� ���� ��û



    int recvLen;
    recvLen=recv(clnt.sock,buffer,BUF_SIZE,0);
//     std::string roomNum=strtok(buffer,"@"); //ä�ù� ����
//     for(int i=0;i<stoi(roomNum);i++)
//     {
//         //ä�ù� �̸� ���
//         std::cout<<strtok(NULL,"@")<<" ";
//         //ä�ù� �ڵ� �����ص־��� --�׷� ���� ���ص���
//         // chatroomList.push_back(strtok(NULL,"@"));
//         //���� �ο�
//         std::cout<<"����: "<<strtok(NULL,"@")<<std::endl; 
//     }
//     std::cout<<"ä�ù��� �����ϼ��� >";
//     char input[2]={0};
//     std::cin>>input;
//     send(clnt.sock,input,sizeof(input),0);
//     //ä�ù� �ڵ带 ������ ������ 
//     //�����κ��� ���ο� ��Ʈ��ȣ �ο�������
//     memset(buffer,0,BUF_SIZE);
//     recv(clnt.sock,buffer,5,0);
//     std::cout<<buffer<<std::endl;
//     buffer[5]=0;
//     //���� ���� ���� ����
//     send(clnt.sock,"THX",4,0);
//     // clnt.~ClientBase();
//     // std::cout<<"���μ��� ���� ���� \n";
//     // Sleep(10000);
//     //���ο� ��Ʈ��ȣ�� �����ϱ� --��������...
//     // ClientBase clntChat(SERVER_IP,buffer);

    return 0;
}
