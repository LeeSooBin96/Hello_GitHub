//�����зο� Ŭ���̾�Ʈ
#include <string>
#include <vector>

#include "clientbase.h"

const unsigned int BUF_SIZE=1024;

std::vector<std::string> chatroomList;

int main()
{
    ClientBase clnt("127.0.0.1","91016");
    //����Ǹ� �г��� �Է� �ޱ�
    std::cout<<"�г����� �Է��ϼ���: (20�� ����)";
    std::string nick;
    std::getline(std::cin,nick);
    while(nick.size()>20)
    {
        std::cout<<"�Էµ� �г���: "<<nick; //Ȯ�ο�
        std::cout<<"�г����� �ٽ� �Է��ϼ���: (20�� ����)";
        std::getline(std::cin,nick);
    }
    //�̴г����� ������ ��������
    send(clnt.sock,nick.c_str(),nick.size(),0);

    //�������� ä�ù����� �޾ƿͼ� Ŭ���̾�Ʈ���� ���������
    char buffer[BUF_SIZE]={0}; //����
    int recvLen;
    recvLen=recv(clnt.sock,buffer,BUF_SIZE,0);
    std::string roomNum=strtok(buffer,"@"); //ä�ù� ����
    for(int i=0;i<stoi(roomNum);i++)
    {
        //ä�ù� �̸� ���
        std::cout<<strtok(NULL,"@")<<" ";
        //ä�ù� �ڵ� �����ص־���
        chatroomList.push_back(strtok(NULL,"@"));
        //���� �ο�
        std::cout<<"����: "<<strtok(NULL,"@")<<std::endl; 
    }
    std::cout<<"ä�ù��� �����ϼ��� >";
    char input;
    std::cin>>input;
    // std::cout<<(int)input; //1=49

    send(clnt.sock,chatroomList[(int)input-49].c_str(),3,0);
    //ä�ù� �ڵ带 ������ ������ 
    //��� �ұ�...?
    
    

    return 0;
}
