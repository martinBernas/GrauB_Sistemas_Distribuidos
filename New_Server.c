// Servidor TCP

#define _OPEN_SYS_ITOA_EXT
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
#include <pthread.h>

#define MAXBUFSIZE 1000
int imprimir;
int posicao_memoria_livre;
pthread_mutex_t mutex1 = PTHREAD_MUTEX_INITIALIZER;
pthread_t conexoes [20];
socklen_t clilen;
struct sockaddr_in servaddr,cliaddr;
typedef struct{
	char nome[20];
	char conteudo[100];
}Campo;
Campo memoria_maquina [20];
int listenfd, connfd, n;

void* coexao_cliente(void *args);

int main()
{	

  	char status[20];
   
   pid_t     childpid;
   //char recv_buffer[MAXBUFSIZE];
   //char send_buffer[MAXBUFSIZE];

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
   int conectados = 0;
   for(;;)
   {
      clilen = sizeof(cliaddr);

      // Aceita conexoes
      connfd = accept(listenfd,(struct sockaddr *)&cliaddr,&clilen);
      pthread_create( &conexoes[conectados],NULL,&coexao_cliente,NULL);
      conectados++;      
   }
}         
void* coexao_cliente(void *args)
{
			char recv_buffer[MAXBUFSIZE];
         char dado[100];
         char send_buffer[MAXBUFSIZE];
         int index=0;
    		int i_command=0;
    		int i_dado=0;
    		char command[15];
			char simprimir[3];
			int loop_status=0;
			char linha_status[1000]={ 0 };

    		char comandos_recebidos[20][100];
         n = 1;
         printf("Cliente Conectou\n");
         while(n > 0)				// Quando n for zero não haverá mais dados a serem lidos e deve-se encerrar a conexão.
        {
			// Recebe dados do socket
            n = recvfrom(connfd, recv_buffer, MAXBUFSIZE, 0,(struct sockaddr *)&cliaddr,&clilen);

            if (recv_buffer[0]=='#')
            {
            	int indice = 0;
            	int x_command = 0;
            	
            	char *pt;
            	pt = strtok(recv_buffer,"$");
            	while(pt){
            		strcpy(comandos_recebidos[indice],pt);
            		pt=strtok(NULL,"$");
            		//printf("%s\n",comandos_recebidos[indice]);
            		indice++; }
           	}else{
           		printf("Comando desconhecido\n");
					strcat(send_buffer, "Comando desconhecido\n");
					recv_buffer[index]=0;
				}
           	int indice = 0;
           	
            pthread_mutex_lock(&mutex1);

           	for(indice = 0; comandos_recebidos[indice][0] == '#'; indice++ ){
           		char *pt;
           		char comando [20];
           		char info [100];
            	pt = strtok(comandos_recebidos[indice],"|");
            	strcpy(comando,pt);
            	pt = strtok(NULL,"|");
            	strcpy(info,pt);
            	pt = strtok(NULL,"|");
            	printf("Processando comando numero: %d\n Comando: %s \t Dado: %s %s\n ",indice,comando,info, pt );
            	if (strcmp(comando,"#Campo_texto")==0){
						printf("Comando Campo texto Recebido: ");
						printf("%s \n",info);
						int d=0;
						for(d=0;d<strlen(info);d++){
							memoria_maquina[posicao_memoria_livre].nome[d]=info[d];
						}
						for(d=0;d<strlen(pt);d++){
							memoria_maquina[posicao_memoria_livre].conteudo[d]=pt[d];
						}
						//strcpy(memoria_maquina[posicao_memoria_livre],info);
						printf("Armazenado:\n\tPosicao memoria: %d Conteudo: %s\n",posicao_memoria_livre,info);
						posicao_memoria_livre ++;
						strcat(send_buffer, "OK\n");
						
					}else if (strcmp(comando,"#Imprimir")==0){
						imprimir=atoi(info);
						printf("Comando Imprimir Recebido: %s\n ",info);
						strcat(send_buffer, "OK\n");
						
					}else if(strcmp(comando,"#Status")==0){
						
						printf("Comando Status Recebido\n");
						
						for(loop_status=0;loop_status<posicao_memoria_livre;loop_status++){
							char conteudo[100];
							strcpy(linha_status, memoria_maquina[loop_status].nome);
							strcat(linha_status,"\t");
							strcpy(conteudo, memoria_maquina[loop_status].conteudo);
							strcat(linha_status,conteudo);
							strcat(linha_status,"\n");
							strcat(send_buffer,linha_status);
						}
						strcat(send_buffer,"\n");
						sprintf(simprimir,"%d",imprimir);
						strcat(send_buffer,"Impressoes restante:\n");
						strcat(send_buffer,simprimir);
					
						

					}else if(strcmp(comando,"#Trigger")==0){
						if (imprimir>0)
						{
							imprimir=imprimir-1;
							if (imprimir>0)
							{
								strcat(send_buffer, "Impressão Feita.\nImpressoes restantes:");
								sprintf(simprimir,"%d",imprimir);
								strcat(send_buffer,simprimir);
							}else{
								strcat(send_buffer, "Acabaram as impressões favor carregue nova etiqueta.\n");
								int loop_limpa_mem = 0;
								for(loop_limpa_mem=0;loop_limpa_mem<posicao_memoria_livre;loop_limpa_mem++){
									memoria_maquina[loop_status].nome[0]=0;
									memoria_maquina[loop_status].conteudo[0]=0;
								}
								posicao_memoria_livre = 0;

							}
							
						
						}else {
							strcat(send_buffer, "Sem Impressoes\n");
						
						}

           	}else if(strcmp(comando,"#Abortar")==0){
           		int loop_limpa_mem = 0;
           		strcat(send_buffer, "Abortadas Impressoes.\n");
					for(loop_limpa_mem=0;loop_limpa_mem<posicao_memoria_livre;loop_limpa_mem++){
						memoria_maquina[loop_status].nome[0]=0;
						memoria_maquina[loop_status].conteudo[0]=0;
					}
					posicao_memoria_livre = 0;
					imprimir = 0;

           	}else if (strcmp(comando,"#Update")==0){
					printf("Comando Update Recebido: ");
					printf("%s \n",info);
					int busca_campo=0;
					int d=0;
					int achou = 0;
					for(busca_campo=0;busca_campo<posicao_memoria_livre && achou == 0;busca_campo++)
					{
						if (strcmp(memoria_maquina[busca_campo].nome,info)==0)
						{
							for(d=0;d<strlen(pt);d++){
								memoria_maquina[busca_campo].conteudo[d]=pt[d];
							}
							memoria_maquina[busca_campo].conteudo[d]=0;
							achou = 1;
							strcat(send_buffer, "Campo ");
							strcat(send_buffer, info);
							strcat(send_buffer, " atualizado.\n");
							printf("Campo %s Atualizado\n",info);
						}
					}
					if (achou == 0)
					{
						strcat(send_buffer, "Erro Campo ");
						strcat(send_buffer, info);
						strcat(send_buffer, " Não localizado.\n");
						printf("Campo %s Não Localizado\n",info);
						
					}
					
					printf("Armazenado:\n\tPosicao memoria: %d Conteudo: %s\n",posicao_memoria_livre,info);
						
				}else{
           		printf("Comando desconhecido\n");
					strcat(send_buffer, "Comando desconhecido\n");
					recv_buffer[index]=0;
           	}
           }
           pthread_mutex_unlock(&mutex1);
			  sendto(connfd, send_buffer, strlen(send_buffer), 0,(struct sockaddr *)&cliaddr,sizeof(cliaddr));
			  send_buffer[0]=0;
			  n = 0;
							
		}


}
