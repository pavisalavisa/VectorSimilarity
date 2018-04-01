using System;
using System.Collections.Generic;
using System.Diagnostics;
/*Dano je polje od n vektora od kojih se svaki sastoji od 3 komponente, a svaka komponenta
 * je cijeli broj od 1 do 20. Definirajmo da su dva vektora bliska
 * ako su im jednake bilo koje dvije komponente. Definirajte O(n) algoritam koji pronade
 * u polju od n vektora dva koja su bliska ili da takva dva ne postoje.
 * 
 * npr (3,15,2) i (3,14,2) su bliski
 * */

namespace VectorSimilarity
{
    class Program
    {

        public class Vektor
        {
             int size;
            public int hits;
             public int[] komponente;

            public Vektor(int size)
            {
                this.size = size;
                this.komponente = new int[size];
            }
            public Vektor(params int[] komponente)
            {
                size = komponente.Length;
                this.komponente = komponente;
                hits = 0;
            }
            public override string ToString()
            {
               return String.Format("{0},{1},{2}", komponente[0], komponente[1], komponente[2]);
            }
            public bool isCloseTo(Vektor vek)
            {
                int n = 0;
                for(int i = 0; i < this.size; i++)
                {
                   if (this.komponente[i] == vek.komponente[i]) n++;
                    
                }
                return n >= 2;
            }

            public bool isSimilar()
            {
                int n = 0;
                for (int i = 0; i < size; i++)
                {
                    if (komponente[i] < 0) n++;
                }
                return n >= 2;
            }
        }
        static void Main(string[] args)
        {
            Vektor[] list = new Vektor[6];
            Random r = new Random();
            for(int i = 0; i < list.Length; i++)
            {
                list[i] = new Vektor(r.Next(1, 5), r.Next(1, 5), r.Next(1, 5));
                Console.WriteLine(list[i]);
            }
            findSimilarVectors(list);
            findSimilarVectorsFine(list);
            Console.ReadKey();
        }
        public static void findSimilarVectorsFine(Vektor[] vectors)
        {
            int counter = 0;
            var sums = new Vektor[vectors.Length];
            var hashTable = new int[1001];
            for (int i = 0; i < vectors.Length; i++)
            {
                sums[i] = new Vektor(3);
                sums[i].komponente[0] = 10*vectors[i].komponente[0] + vectors[i].komponente[1];
                sums[i].komponente[1] = 10*vectors[i].komponente[0] + vectors[i].komponente[2];
                sums[i].komponente[2] = 10*vectors[i].komponente[1] + vectors[i].komponente[2];
                Console.WriteLine("Sume su: {0}, {1}, {2}", sums[i].komponente[0], sums[i].komponente[1], sums[i].komponente[2]);
            }

            for(int i = 0; i < vectors.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("{0},{1} hash vrijednost:{2}", i, j, hashFunction(sums[i].komponente[j], j));
                    if (hashTable[hashFunction(sums[i].komponente[j], j)] == 0)
                        hashTable[hashFunction(sums[i].komponente[j], j)] = 1;
                    else
                    {
                        if (flag == false)
                        {
                            Console.WriteLine("We've found them!" + vectors[i]);
                            counter++;
                            flag = true;
                        }
                    }
                }
            }
            Console.WriteLine("Using O(n) approach we got {0} similar vectors.", counter);

        }

        private static int hashFunction(int value,int position)
        {
            switch (position)
            {
                case 0:
                    return (value * 23) % 1001;
                    break;
                case 1:
                    return (value * 29) % 1001;
                    break;
                case 2:
                    return (value * 31) % 1001;
                    break;
                default:
                    return (value * 37) % 1001;
                    break;
            }
        }

        public static void findSimilarVectors(Vektor[] vectors)
        {
            int counter = 0;
            for(int i=0;i<vectors.Length;i++)
            {
                for(int j=0;j<vectors.Length;j++)
                {
                    if(i!=j && vectors[i].isCloseTo(vectors[j]))
                    {
                        counter++;
                        Console.WriteLine("We've found them!"+vectors[i]+" "+vectors[j]);
                    }
                }
            }
            Console.WriteLine("There was {0} similair vecs", counter);
        }
    }
}
