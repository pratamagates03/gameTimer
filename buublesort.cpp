#include<iostream>
#include<conio.h>

using namespace std;

int main() {
	int jum,tamp;
	cout<<"Tentukan Jumlah data : ";
	cin>>jum;
	
	int data[jum];
	for(int i=0;i<jum;i++) {
		cout<<"Data ke-"<<i+1<<":";
		cin>>data[i];
	}
	
	cout<<"\nNilai array : ";
	for(int i=0;i<jum;i++) {
		cout<<data[i]<<" ";
	}
	
	for(int i=0;i<jum;i++) {
		for(int j=0;j<jum;j++) {
			if(data[j]>data[i]) {
				tamp=data[j];
				data[j]=data[i];
				data[i]=tamp;
			}
		}
	}
	
	cout<<"\nSetelah BubbleSort : ";
	for(int i=0;i<jum;i++) {
		cout<<data[i]<<" ";
	}
}
