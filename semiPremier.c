#include <stdio.h>
#include <stdlib.h>
//declaration de la fonction qui verifie si un nombre est premier
unsigned int premier(int nombre);
//fonction principale
int main(int argc, char* argv[]){
    const long int N = 4;
    int nombre = 1;
    int p, q;
    //chercher p et q telque N = pq et p premier, q premier
    //Je prends N je le divise par tous les nombres premiers inferieurs a lui
    printf("(p, q) = { ");
    while(nombre < N){
        //si nombre est premier
        if(premier(nombre)){
            //je verifie que N % nombre = 0
            if(N % nombre == 0){
                //je verifie que le quotient de N sur nombre est premier
                if(premier(N / nombre)){
                    //si c'est le cas alors N = nombre * (N / nombre)
                    p = nombre;
                    q = N / nombre;
                    printf("(%d, %d), ", p, q);
                }
            }
        }
        nombre++;
    }
    printf("}");
    return 0;
}
//definition de la fonction qui verifie si un  nombre est premier
unsigned int premier(int nombre){
    int diviseur = 1;
    unsigned int r = 0;
    //je cherche les diviseurs de ce nombre jusqu'a lui meme
    while(diviseur <= nombre){
        //je verifie si nombre divise diviseur
        if(nombre % diviseur == 0){
            //r calcul le nombre de diviseur positif de nombre
            r++;
            //si r = 2 a la fin alors nombre est premier
        }
        diviseur++;
    }
    if(r == 2){
        return 1;
    }
    else
        return 0;
}
