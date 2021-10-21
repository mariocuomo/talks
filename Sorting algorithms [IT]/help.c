#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void riempiSequenza(int sequenza[], int n);
void stampaSequenza(int sequenza[], int n);
int verificaSeOrdinata(int sequenza[], int n);
int stupidSort(int sequenza[], int n);
void mescola(int sequenza[], int n);
int selectionSort(int sequenza[], int n);
int mergeSort(int sequenza[], int start, int end);
void merge(int sequenza[], int start, int center, int end);

int main(){
	srand(time(0));
	int sequenza[10];


	/*
	=======================
	      STUPID SORT
	=======================
	*/
	printf("\n================\n");
	printf("STUPID SORT\n");
	printf("================\n");
	riempiSequenza(sequenza,10);
	printf("Ecco la sequenza:\n");
	stampaSequenza(sequenza, 10);

	if(verificaSeOrdinata(sequenza, 10))
		printf("La sequenza e' ordinata\n");
	else
		printf("La sequenza non e' ordinata\n");

	printf("La sequenza e' stata ordinata con l'algoritmo stupid sort in %d passaggi\n", stupidSort(sequenza, 10));
	printf("Ecco la sequenza ordinata:\n");

	stampaSequenza(sequenza, 10);



	/*
	=======================
	    SELECTION SORT
	=======================
	*/
	printf("\n================\n");
	printf("SELECTION SORT\n");
	printf("================\n");
	riempiSequenza(sequenza,10);
	printf("Sto generando dei nuovi numeri...\n");
	printf("Ecco la sequenza:\n");
	stampaSequenza(sequenza, 10);

	if(verificaSeOrdinata(sequenza, 10))
		printf("La sequenza e' ordinata\n");
	else
		printf("La sequenza non e' ordinata\n");

	printf("La sequenza e' stata ordinata con l'algoritmo selection sort in %d passaggi\n", selectionSort(sequenza, 10));
	printf("Ecco la sequenza ordinata:\n");

	stampaSequenza(sequenza, 10);


	/*
	=======================
	    MERGE SORT
	=======================
	*/
	printf("\n================\n");
	printf("MERGE SORT\n");
	printf("================\n");
	riempiSequenza(sequenza,10);
	printf("Sto generando dei nuovi numeri...\n");
	printf("Ecco la sequenza:\n");
	stampaSequenza(sequenza, 10);

	if(verificaSeOrdinata(sequenza, 10))
		printf("La sequenza e' ordinata\n");
	else
		printf("La sequenza non e' ordinata\n");

	printf("La sequenza e' stata ordinata con l'algoritmo merge sort in %d passaggi\n", mergeSort(sequenza, 0, 9));
	printf("Ecco la sequenza ordinata:\n");

	stampaSequenza(sequenza, 10);

}


void riempiSequenza(int sequenza[], int n){
	for(int i=0; i<n;i++){
		sequenza[i]=rand()%10;
	}
}

void stampaSequenza(int sequenza[], int n){
	for(int i=0; i<n;i++){
		printf("%d ",sequenza[i]);
	}
	printf("\n");

}

int verificaSeOrdinata(int sequenza[],  int n){
	for(int i=0;i<n-1;i++)
		if(sequenza[i]>sequenza[i+1])
			return 0;
	return 1;
}

int stupidSort(int sequenza[], int n){
	int i=0;
	while(!verificaSeOrdinata(sequenza,n)){
		mescola(sequenza, n);
		i++;
	}
	return i;
}

void mescola(int sequenza[], int n){
	for (int i = 0; i < n; i++){
    	int e1 = rand()%n;
    	int e2 = rand()%n;

    	int temp = sequenza[e1];
    	sequenza[e1] = sequenza[e2];
    	sequenza[e2] = temp;
    }
}


int selectionSort(int sequenza[], int n){
	int count=0;
	for(int i=0;i<=n-2;i++){
		count++;
		int posmin=i;
		for(int j=i+1;j<=n-1;j++){
			count++;
			if(sequenza[j]<sequenza[posmin])
				posmin=j;
		}
		if(posmin!=i){
			int tmp=sequenza[i];
			sequenza[i]=sequenza[posmin];
			sequenza[posmin]=tmp;
		}
	}
	return count;
}

int mergeSort(int sequenza[], int start, int end){
	int i=0:
	if(start<end){
		int center = (start+end)/2;
		mergeSort(sequenza,start,center);
		mergeSort(sequenza,center+1,end);
		merge(sequenza,start,center,end);
		i+=2;
	}

	return i;
}

void merge(int sequenza[], int start, int center, int end){
	int i=start;
	int j=center+1;
	int k=0;

	int array_temp[end-start+1];

	while(i<=center && j<=end){
		if(sequenza[i]<sequenza[j]){
			array_temp[k]=sequenza[i];
			i++;
		}
		else{
			array_temp[k]=sequenza[j];
			j++;
		}
		k++;
	}

	while(i<=center){
		array_temp[k]=sequenza[i];
		i++;
		k++;
	}

	while(j<=end){
		array_temp[k]=sequenza[j];
		j++;
		k++;
	}

	for(k=start;k<=end;k++){
		sequenza[k]=array_temp[k-start];
	}
}
