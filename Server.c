// Servidor TCP

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <unistd.h>
#include <time.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>

#define MAXBUFSIZE 1000

int main()
{	

	int index=0;
    int i_command=0;
    int i_dado=0;
    char command[15];
    char dado[100];
	
   int listenfd, connfd, n;
   struct sockaddr_in servaddr,cliaddr;
   socklen_t clilen;
   pid_t     childpid;
   char recv_buffer[MAXBUFSIZE];
   char send_buffer[MAXBUFSIZE];

   listenfd=socket(AF_INET,SOCK_STREAM,0);

   bzero(&servaddr,sizeof(servaddr));
   servaddr.sin_family = AF_INET;
   servaddr.sin_addr.s_addr=htonl(INADDR_ANY);

   servaddr.sin_port=htons(32000); //Big-endian x little endian

   bind(listenfd,(struct sockaddr *)&servaddr,sizeof(servaddr));

   // Escuta, permitindo ate 1024 conexoes simultaneas
   listen(listenfd, 1024);

   system("clear");
   printf("\t##### TCP server #####\n");
   printf("\tWaiting for requests...\n");
   
   for(;;)
   {
      clilen = sizeof(cliaddr);

      // Aceita conexoes
      connfd = accept(listenfd,(struct sockaddr *)&cliaddr,&clilen);

      if ((childpid = fork()) == 0) //fork() cria processos filhos para atender aos clientes. childpid só é zero dentro do processo filho, 
									// então esse if separa os códigos que devem ser executados pelo filho e pelo pai
									// fork() retorna um valor negativo em caso de erro.
      {
         n = 1;
         while(n > 0)				// Quando n for zero não haverá mais dados a serem lidos e deve-se encerrar a conexão.
        {
			// Recebe dados do socket
			recv_buffer[0] = '#';
            n = recvfrom(connfd, recv_buffer, MAXBUFSIZE, 0,(struct sockaddr *)&cliaddr,&clilen);
            //recv_buffer[n] = '\0';
			
			
			
			    while(index < strlen(recv_buffer)){

					if(recv_buffer[index] == '#'){
						while(recv_buffer[index] != '|'){
							command[i_command] = recv_buffer[index];
							i_command++;
							index++;
						}
						command[i_command]=0;
						while(recv_buffer[index] != '$'){
							index++;
							dado[i_dado] = recv_buffer[index];
							i_dado++;
						}
						dado[i_dado]=0;
						i_command=0;
						i_dado=0;
						index++;
					}
						if (strcmp(command,"#Campo_texto")==0){
							printf("Campo_texto: ");
							printf("%s \n",dado);
							strcpy(send_buffer, "Comando de texto \n");
							sendto(connfd, send_buffer, strlen(send_buffer), 0,(struct sockaddr *)&cliaddr,sizeof(cliaddr));
						}

						if (strcmp(command,"#Imprimir")==0){
							printf("Imprimir: ");
							printf("imprimindo...");
							strcpy(send_buffer, "Comando de imprimir\n");
							sendto(connfd, send_buffer, strlen(send_buffer), 0,(struct sockaddr *)&cliaddr,sizeof(cliaddr));
						}

						if (strcmp(command,"#Status")==0){
							printf("Status: ok ");
							strcpy(send_buffer, "Comando de status\n");
							sendto(connfd, send_buffer, strlen(send_buffer), 0,(struct sockaddr *)&cliaddr,sizeof(cliaddr));
						}
				}
		
		
		
		}
      }
   }
}         
