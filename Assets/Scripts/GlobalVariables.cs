using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables {

	public static int nLevels = 20;
	//-2: final
	//-1: inicial
	//0: nada
	//1: normal
	//2: camino
	//3: suma
	//4: sustraccion
	//5: multiplicacion
	//6: division
	//7: CW
	//8: CCW
	//9: muerte


	//new 
	//2: red
	//3: yellow
	//4: blue
	//5: orange
	//7: green
	//6: purple 


	//10X: camino con un numero especifico (X)

	//Stages
	/*
	suma
	1*
	2*
	3*
	//rotacion
	4*
	5*
	//sustraccion
	6*
	7*
	8*
	9
	10
	//multiplicacion
	11
	12
	13*
	14*
	15*
	//division
	16
	17*
	18*
	19*
	20*
	*/


	//1?

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4     
	/*public static string Scene1 = "5|5|3|1|1$   9|   9|   9|   9|   9|" +
											"   9|   1|   1|  -1|   9|" +
											"   9|   1|   1|   1|   9|" +
											"   9|  -2|   1|   1|   9|" +
											"   9|   9|   9|   9|   9|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene1Numbers = "1|1|1$    0|   0|   0|   0|   0|" +
												"   0|   4|   2|   0|   0|" +
												"   0|   6|   3|   3|   0|" +
												"   0|   0|   5|   6|   0|" +
												"   0|   0|   0|   0|   0|";

	public static string Scene1Path = "1,2|2,2|3,2";*/

	public static string Scene1 = "5|5|4|0|0$  -4|  -4|   1|   1|  -1|" +
											"  -4|  -4|   1|   1|   1|" +
											"  -4|  -3|  -3|   1|   1|" +
											"  -4|  -3|  -3|  -3|  -4|" +
											"  -4|  -3|  -3|  -3|  -4|";

	public static string Scene1Numbers = "1|1|1$   20|  18|   3|   2|   0|" +
												"  15|  12|   5|   4|   3|" +
												"  10|   4|   2|   7|   4|" +
												"  14|   2|   3|   7|   4|" +
												"  21|  28|   5|  24|   6|";

	public static string Scene1Path = "1,2|2,2|3,2";

	//2

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6  
	public static string Scene2 = "6|7|5|1|0$	1|   1|   1|   1|   1|   1|   1|" +
											"   1|   2|   2|   2|   2|  -1|   1|" +
											"   1|   2|   1|   1|   1|   1|   1|" +
											"   1|   2|   1|   0|   0|   0|   0|" +
											"   1|  -2|   1|   0|   0|   0|   0|" +
											"   1|   1|   1|   0|   0|   0|   0|";


	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene2Numbers = "1|1|1$   -4|  -7|   5|   1|   4|   4|   2|" +
												"  -3|   8|   5|   3|   2|   0|   3|" +
												"   2|   9|   9|   7|   4|   5|   4|" +
												"   3|  17|   3|   0|   0|   0|   0|" +
												"  30|   0|  32|   0|   0|   0|   0|" +
												"  14|   6|  17|   0|   0|   0|   0";

	public static string Scene2Path = "1,4|1,3|1,2|1,1|2,1|3,1";


	//3
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8   
	public static string Scene3 = "10|9|7|1|0$  0|   0|   0|   0|   0|   1|   1|   1|   1|" +
											"   0|   0|   1|   1|   1|   1|   1|  -1|   1|" +
											"   0|   0|   1|   1|   1|   1|   1|   1|   1|" +
											"   0|   0|   1|   1|   1|   1|   1|   1|   0|" +
											"   1|   1|   1|   1|   1|   1|   1|   0|   0|" +
											"   1|   1|   1|   1|   1|   1|   0|   0|   0|" +
											"   1|   1|   1|   1|   1|   0|   0|   0|   0|" +
											"   1|   1|   1|   1|   1|   0|   0|   0|   0|" +
											"   1|   1|   1|   1|   1|   0|   0|   0|   0|" +
											"   1|  -2|   1|   1|   1|   0|   0|   0|   0|";

	//filas|columnas|posxini|posyini|imgtut	  	  //0    1    2    3    4    5    6    7    8  
	public static string Scene3Numbers = "3|4|3$    0|   0|   0|   0|   0|  20|  12|   3|   4|" +
												"   0|   0|  43|  37|  28|  12|   9|   0|   5|" +
												"   0|   0|  43|  33|  26|  16|  10|   6|   8|" +
												"   0|   0|  54|  38|  29|  27|  19|  14|   0|" +
												" 213| 124|  99|  71|  55|  47|  42|   0|   0|" +
												"  98| 262| 123| 100|  98|  74|   0|   0|   0|" +
												" 182| 347| 226| 171| 101|   0|   0|   0|   0|" +
												" 284| 368| 326| 243| 187|   0|   0|   0|   0|" +
												" 583| 723| 552| 344| 258|   0|   0|   0|   0|" +
												" 642|  -2| 736| 541| 345|   0|   0|   0|   0|";

	public static string Scene3Path = "2,7|2,6|2,5|2,4|3,4|4,4|4,3|5,3|6,3|6,2|7,2|8,2|8,1|9,1";


	//4
	//old 4
	/*
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8 
	public static string Scene4 = "8|9|5|1|0$   0|   0|   0|   0|   1|   1|   1|   0|   0|" +
											"   0|   0|   0|   0|   1|  -1|   1|   0|   0|" +
											"   0|   0|   0|   0|   1|   1|   1|   1|   1|" +
											"   1|   1|   1|   0|   1|   7|   1|   1|   1|" +
											"   1|   1|   1|   0|   1|   1|   1|   1|   1|" +
											"  -2|   1|   1|   9|   9|   1|   1|   8|   1|" +
											"   1|   1|   8|   1|   1|   1|   1|   9|   0|" +
											"   1|   1|   1|   9|   9|   9|   9|   0|   0|";

	//filas|columnas|posxini|posyini|imgtut	      //0    1    2    3    4    5    6    7    8  
	public static string Scene4Numbers = "1|1|1$    0|   0|   0|   0|   5|   4|   2|   0|   0|" +
												"   0|   0|   0|   0|   2|   0|   1|   0|   0|" +
												"   0|   0|   0|   0|   4|   2|   5|  -1|   5|" +
												" 233| 234| 266|   0|   4|   3|   5|   8|   9|" +
												" 223| 340| 358|   0|   5|   3|  34|   9|  16|" +
												"   0| 361| 318|   0|   0|  43|  26|  17|  34|" +
												" 123| 315| 196| 122|  74|  48|  41|   0|   0|" +
												" 130| 234| 236|   0|   0|   0|   0|   0|   0|";

	public static string Scene4Path = "2,5|3,5|3,6|3,7|4,7|5,7|5,6|5,5|6,5|6,4|6,3|6,2|5,2|5,1";
	*/

	//filas|columnas|posxini|posyini|imgtut	    //0    1    2    3    4    5    6    7    8 
	public static string Scene4 = "9|9|4|4|0$     1|   1|   1|   1|   1|   1|   1|   1|   1|" +
				                              "   1|   1|   1|   1|   1|   8|   1|   1|   1|" +
				                              "   1|   1|   8|   1|   1|   1|   1|   1|   1|" +
				                              "   1|   1|   1|   1|   1|   1|   1|   1|   1|" +
				                              "   1|   1|   1|   1|  -1|   1|  -2|   1|   1|" +
				                              "   1|   1|   1|   1|   1|   1|   0|   0|   0|" +
				                              "   1|   1|   1|   1|   8|   1|   0|   0|   0|" +
				                              "   1|   1|   1|   1|   1|   1|   0|   0|   0|" +
				                              "   1|   1|   1|   1|   1|   1|   0|   0|   0|";

	//filas|columnas|posxini|posyini|imgtut	      //0    1    2    3    4    5    6    7    8  
	public static string Scene4Numbers = "1|1|1$   53|  42|  78|  60| 109| 132| 230| 319| 334|" +
												"  39|  40|  65|  74| 117| 191| 243| 311| 451|" +
												"  36|  41|  43|  69| 190| 308| 377| 223| 235|" +
												"  32|  31|  26|   6|   4| 341| 568| 521| 431|" +
												"  34|  26|  17|   1|   0|   3|  34| 523| 443|" +
												"  12|  16|   9|  12|   2|   3|   0|   0|   0|" +
												"  33|  12|   8|   5|   3|   4|   0|   0|   0|" +
												"  23|  21|  10|  12|   7|   8|   0|   0|   0|" +
												"  13|  14|  15|  15|   9|   3|   0|   0|   0|";

	public static string Scene4Path = "5,4|6,4|6,3|6,2|5,2|4,2|3,2|2,2|2,3|1,3|1,4|1,5|2,5|2,6|3,6|4,6";

	//old 6
	/*//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4     
	public static string Scene6 = "7|7|5|1|0$   0|   9|   9|   9|   9|   9|   0|" +
											"   9|   7|   1|   1|   1|  -1|   9|" +
											"   9|   1|   1|   1|   9|   9|   0|" +
											"   9|   1|   1|   8|   9|   0|   0|" +
											"   9|   1|   1|   1|   9|   0|   0|" +
											"   9|  -2|   1|   8|   9|   0|   0|" +
											"   0|   9|   9|   9|   0|   0|   0|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene6Numbers = "7|2|1$    0|   0|   0|   0|   0|   0|   0|" +
												"   0|  41|  25|  16|   9|   0|   0|" +
												"   0|  65|  30|  41|  24|   8|   0|" +
												"   0|  72|  32|  57|   2|  64|   0|" +
												"   0|  90|  75|  58|   6|  32|   0|" +
												"   0|   0| 173| 115|   4| 256|   0|" +
												"   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene6Path = "1,4|1,3|1,2|1,1|2,3|3,3|4,3|5,3|5,2";
	*/

	//5

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8   
	public static string Scene5 = "8|11|2|2|0$  9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|" +  
											"	9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|" +
											"   9|   1|  -1|   1|   1|   8|   1|   1|   1|   1|   9|" +
											"   9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|" +
											"   9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|" +
											"   9|   1|   7|   1|   1|   7|   1|   1|  -2|   1|   9|" +
											"   9|   1|   1|   1|   1|   1|   1|   1|   1|   1|   9|" +
											"   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|";

	//filas|columnas|posxini|posyini|imgtut	  	  //0    1    2    3    4    5    6    7    8  
	public static string Scene5Numbers = "1|1|1$    0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|"+ 
												"   0|   4|   3|   7|  52|  91| 130| 340| 376| 400|   0|" +
												"   0|   1|   0|   4|  71|  89| 144| 233| 377| 450|   0|" +
												"   0|   4|   2|   3|  65|  55| 145| 212| 378| 750|   0|" +
												"   0|   3|   3|   5|  21|  34|  36| 300| 755| 999|   0|" +
												"   0|   6|   5|   8|  13|  21|  32|  65|   0| 980|   0|" +
												"   0|   9|  14|  10|  12|  22|  25|  15|  80| 641|   0|" +
												"   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";

	//fila,columna
	public static string Scene5Path = "3,2|4,2|5,2|5,3|5,4|5,5|4,5|3,5|2,5|2,6|2,7|2,8|3,8|4,8";



	//6
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8    9   10
	public static string Scene6 = "6|11|9|1|2$  0|   0|   0|   0|   1|   1|   1|   1|   1|   1|   1|" +
											"   0|   0|   0|   0|   1|   1|   1|   4|   1|  -1|   1|" +
											"   0|   0|   0|   0|   1|   3|   1|   1|   1|   1|   1|" +
											"   1|   1|   1|   1|   1|   1|   1|   0|   0|   0|   0|" +
											"   1|  -2|   1|   1|   4|   1|   1|   0|   0|   0|   0|" +
											"   1|   1|   1|   1|   1|   1|   1|   0|   0|   0|   0|";

	//filas|columnas|posxini|posyini|imgtut	  	  //0    1    2    3    4    5    6    7    8    9   
	public static string Scene6Numbers = "1|3|2$    0|   0|   0|   0|  -4|  -7|   5|   1|   4|   4|   2|" +
												"   0|   0|   0|   0|  -3|  -4|   1|   5|   4|   0|   3|" +
												"   0|   0|   0|   0|  -7|  -6|   1|   4|   4|   5|   4|" +
												"  -1|   3|  17|   3|   9| -10|   5|   0|   0|   0|   0|" +
												"   3|   0|  16|   1| -15| -16|   5|   0|   0|   0|   0|" +
												"  -7|  14|   8|  13|  -2|   9|   6|   0|   0|   0|   0|";

	public static string Scene6Path = "1,8|1,7|1,6|1,5|2,5|3,5|4,5|4,4|4,3|4,2";


	//7
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    
	public static string Scene7 = "7|7|5|1|0$   0|   9|   9|   9|   9|   9|   0|"+
											"   9|   1|   1|   1|   4|  -1|   9|" +
											"   9|   1|   7|   1|   1|   4|   9|" +
											"   9|   1|   3|   0|   3|   1|   9|" +
											"   9|   1|   1|   1|   1|   1|   9|" +
											"   9|   1|   1|   4|   1|  -2|   9|" +
											"   0|   9|   9|   9|   9|   9|   0|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene7Numbers = "10|3|7$   0|   0|   0|   0|   0|   0|   0|" +
												"   0|  35|  14|   3|  13|   0|   0|" +
												"   0|  16| -17|  -4|  14|  16|   0|" +
												"   0|  15| -13|   0|   5|  24|   0|" +
												"   0|  12| -30|   8|  19|  32|   0|" +
												"   0|  20| -43| -40|   3| 256|   0|" +
												"   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene7Path = "1,4|1,3|2,3|2,2|3,2|4,2|5,2|5,3|5,4";


	//8
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8 
	public static string Scene8 = "6|6|4|0|0$  0|   0|   0|   9|  -1|   1|" +
											"   0|   9|   9|   9|   1|   7|" +
											"   0|   9|   8|   1|   1|   3|" +
											"   7|   1|   1|   9|   4|   1|" +
											"  -2|   1|   8|   1|   1|   1|" +
											"   1|   1|   1|   9|   9|   1|";

	//filas|columnas|posxini|posyini|imgtut	      //0    1    2    3    4    5    6    7    8  
	public static string Scene8Numbers = "1|1|1$   0|   0|   0|   0|   5|   4|" +
												"   0|   0|   0|   0|   2|   3|" +
												"   0|   0|  -1|   1|   3|  -2|" +
												"  -5|  -7|  -2|   0|   5|   3|" +
												"   5|   4|  -1|   1|   2|   3|" +
												"   0|   3|   5|   0|   0|   4|";

	public static string Scene8Path = "1,4|2,4|3,4|4,4|4,3|4,2|3,2|3,1|3,0";


	//9

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8 
	public static string Scene9 = "8|9|5|1|0$  0|   0|   0|   0|   1|   1|   1|   0|   0|" +
											"   0|   0|   0|   0|   1|  -1|   1|   0|   0|" +
											"   0|   0|   0|   0|   1|   1|   1|   1|   1|" +
											"   1|   1|   1|   0|   1|   7|   4|   1|   1|" +
											"   1|   1|   1|   0|   1|   1|   1|   1|   1|" +
											"  -2|   1|   1|   9|   9|   1|   1|   8|   1|" +
											"   1|   1|   8|   1|   1|   3|   1|   9|   0|" +
											"   1|   1|   1|   9|   9|   9|   9|   0|   0|";

	//filas|columnas|posxini|posyini|imgtut	      //0    1    2    3    4    5    6    7    8  
	public static string Scene9Numbers = "1|1|1$   0|   0|   0|   0|   5|   4|   2|   0|   0|" +
												"   0|   0|   0|   0|   2|   0|   1|   0|   0|" +
												"   0|   0|   0|   0|   4|   2|   5|   2|  -2|" +
												"  33|  34|  45|   0|   4|   3|   5|   2|   4|" +
												"  23| -56| -50|   0|   5|   3|   0|   1|   3|" +
												"   0| -37| -36|   0|   0|  -1|  -2|  -1|  12|" +
												"  23| -21| -22| -14|  -8|  -6|  -9|   0|   0|" +
												"  34|  28|  36|   0|   0|   0|   0|   0|   0|";

	public static string Scene9Path = "2,5|3,5|3,6|3,7|4,7|5,7|5,6|5,5|6,5|6,4|6,3|6,2|5,2|5,1";

	//10
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6   
	public static string Scene10 = "7|7|5|1|0$  1|   1|   1|   1|   1|   1|   1|" +
											"   1|   7|   4|   1|   1|  -1|   1|" +
											"   1|   1|   8|   1|   1|   1|   1|" +
											"   1|   1|   3|   1|   1|   8|   1|" +
											"   1|   1|   1|   1|   1|   3|   1|" +
											"   1|   7|   4|   7|   1|   1|   1|" +
											"   1|   1|   1|   1|   1|  -2|   1|";



	//filas|columnas|posxini|posyini|imgtut	 	  //0    1    2    3    4    5    6
	public static string Scene10Numbers = "1|1|1$   2|  10|   3|   5|   5|   4|   4|" +
												"   3|   9|  11|   8|   2|   0|   4|" +
												"  -8|  -2|   7|   4|   3|   4|   4|" +
												" 165|  73|  -2|  29| -35| -21|   6|" +
												"  27|  16|   5| -14| -19|  14|  22|" +
												" 209|  14|  30|  16| -40| -75|  25|" +
												"  29|  29|  35|  31|  25|   0|  25|";

	public static string Scene10Path = "1,4|2,4|2,3|2,2|1,2|1,1|2,1|3,2|4,2|4,1|5,1|5,2|5,3|4,3|4,4|3,4|3,5|4,5|5,4|5,5";


	//11

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6  
	public static string Scene11 = "7|7|5|1|3$   0|   0|   0|   0|   0|   1|   0|" +
											"   0|   0|   0|   0|   1|  -1|   1|" +
											"   0|   0|   0|   0|   1|   1|   1|" +
											"   0|   0|   0|   0|   1|   1|   1|" +
											"   0|   1|   1|   1|   1|   4|   1|" +
											"   1|  -2|   1|   1|   1|   5|   1|" +
											"   0|   1|   1|   1|   1|   1|   1|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene11Numbers = "3|1|2$    0|   0|   0|   0|   0|   4|   0|" + //0
												"   0|   0|   0|   0|   5|   0|   6|" + //1
												"   0|   0|   0|   0|  -3|   5|  20|" + //2
												"   0|   0|   0|   0|  13|   8|  21|" + //3
												"   0|-250| 100|   3|  11|  13|  15|" + //4
												"  35|   0| 125|  25|   5|   5|  30|" + //5
												"   0| 259| 525|  23|  18|   8|   1";   //6

	public static string Scene11Path = "1,5|2,5|3,5|4,5|5,5|5,4|5,3|5,2";


	//12

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8   
	public static string Scene12 = "8|9|6|2|0$  0|   0|   0|   0|   0|   0|   0|   0|   0|" +
											"   0|   1|   5|   1|   1|   1|   1|   1|   0|" +
											"   0|  -2|   1|   8|   1|   4|  -1|   1|   0|" +
											"   0|   1|   1|   1|   1|   1|   5|   1|   0|" +
											"   0|   1|   1|   4|   8|   1|   1|   1|   0|" +
											"   0|   1|   1|   1|   1|   3|   1|   1|   0|" +
											"   0|   1|   1|   1|   4|   8|   1|   1|   0|" +
											"   0|   1|   1|   1|   1|   1|  -2|   1|   0|";

	//dadoUp/dadoLeft/dadoForward	  	 		  //0    1    2    3    4    5    6    7    8  
	public static string Scene12Numbers = "4|3|1$   0|   0|   0|   0|   0|   0|   0|   0|   0|" +
												"   0|   5|  -3|   1|  -1|   3|  -4|   1|   0|" +
												"   0|   0|-140|  -8|  -2|   7|   0|  35|   0|" +
												"   0| -90| -55|  25|   1|   9|   5|   7|   0|" +
												"  -4|   3|  -4|  85|  80|  60|  20|  15|   0|" +
												"   0|  30|  18|  12|  85| 300|  25|  -3|   0|" +
												"   6|  14|   9|  20| 100|  80|   1|   2|   0|" +
												"   6|  14|   9|  15| -30|   5|   0|   4|   0|";

	public static string Scene12Path = "3,6|4,6|4,5|5,5|4,4|4,3|3,3|3,2|2,2";


	//13

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6  
	public static string Scene13 = "8|9|7|4|0$  0|   9|   1|   1|   1|   9|   9|   0|   0|" +
											"   0|   9|   1|   1|   1|   9|   9|   0|   0|" +
											"   9|   1|   5|   1|  -2|   1|   9|   9|   0|" +
											"   9|   1|   1|   8|   0|   1|   1|   1|   9|" +
											"   9|   1|   1|   3|   8|   1|   1|  -1|   9|" +
											"   9|   9|   9|   1|   1|   4|   1|   1|   9|" +
											"   0|   0|   9|   1|   1|   1|   9|   9|   0|" +
											"   0|   0|   9|   9|   9|   9|   9|   9|   0|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene13Numbers = "5|3|1$   0|   0|  -7|  13| -11|   0|   0|   0|   0|" + //0
												"   0|   0|   4|  -5|   8|   0|   0|   0|   0|" + //1
												"   0| -11| -19|   2|   0| 363|   0|   0|   0|" + //2
												"   0|  30|  -8| -18|   0| -33|  -5|  15|   0|" + //3
												"   0|  67| -11|  -6|  -5|   3|   8|   0|   0|" + //4
												"   0|   0|   0|  -4|  20|  14|   9|   7|   0|" + //5
												"   0|   0|   0|  15|   7|  -6|   0|   0|   0|" + //6
												"	0|   0|   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene13Path = "4,6|5,6|5,5|4,5|4,4|4,3|4,2|3,2|2,2|3,3|3,5|2,5";



	//14

	//filas|columnas|posxini|posyini|imgtut	      //0    1    2    3    4    5    6    7    8   
	public static string Scene14 = "11|11|4|1|0$    9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|" +
												"   9|   9|   4|   1|  -1|   1|  -2|   1|   1|   9|   9|" +
												"   9|   7|   1|   4|   1|   1|   1|   1|   1|   1|   9|" +
												"   9|   1|   7|   1|   0|   0|   0|   1|   7|   7|   9|" +
												"   9|   1|   3|   0|   0|   0|   0|   0|   1|   1|   9|" +
												"   9|   3|   1|   0|   0|   0|   0|   0|   3|   3|   9|" + //4
												"   9|   1|   1|   0|   0|   0|   0|   0|   1|   1|   9|" +
												"   9|   1|   4|   1|   0|   0|   0|   7|   1|   1|   9|" +
												"   9|   4|   1|   7|   1|   5|   1|   4|   7|   1|   9|" +
												"   9|   9|   7|   1|   5|   1|   1|   1|   4|   9|   9|" +
												"   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|   9|";

	//dadoUp/dadoLeft/dadoForward	          	  //0    1    2    3    4    5    6    7    8  
	public static string Scene14Numbers = "1|8|5$   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|" +
												"   0|   0|   7|   9|   0|-700|   0|   5|  -1|   0|   0|" + //0
												"   0|  -1|  13|  14|   7|-700|   3|   4|   6|   2|   0|" + //1
												"   0| -14|  25|  15|   0|   0|   0|   8|   4|  13|   0|" + //2
												"   0| -13| -12|   0|   0|   0|   0|   0|  15|  -2|   0|" + //3
												"   0|   1|  10|   0|   0|   0|   0|   0|  80|  54|   0|" + //4
												"   0| -15|  -3|   0|   0|   0|   0|   0| 154|  72|   0|" + //5
												"   0|  -4|   7|   9|   0|   0|   0| 424| 160|  98|   0|" + //6
												"   0|   3|  10|  12| -13|  69| 800| 832| 256| 145|   0|" + //7
												"   0|   0|   3|  -7| -10|  70|-700| 756| 640|   0|   0|" + //8
												"   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene14Path = "1,3|2,3|2,2|2,1|3,1|4,1|5,1|5,2|6,2|7,2|8,2|9,2|9,3|9,4|9,5|9,6|1,5";


	//15

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6
	public static string Scene15 = "9|8|6|5|0$  0|   9|   9|   9|   9|   9|   0|   0|" + //0
											"   9|   5|   7|   4|   8|   1|   9|   0|" +
											"   9|   8|   4|   3|   5|   1|  -2|   9|" +
											"   9|   4|   5|   4|   3|   9|   9|   0|" +
											"   9|   3|   4|   3|   4|   9|   9|   0|" +
											"   9|   4|   8|   5|   3|   5|  -1|   9|" +
											"   9|   5|   4|   8|   1|   1|   9|   9|" +
											"   0|   9|   9|   9|   9|   9|   0|   0|" +
											"   0|   0|   0|   0|   0|   0|   0|   0|";

	//dadoUp/dadoLeft/dadoForward		          //0    1    2    3    4    5    6
	public static string Scene15Numbers = "2|2|1$   0|   0|   0|   0|   0|   0|   0|   0|" + //0
												"   0| 256| 360|-508|2056|4112|   2|   0|" + //1
												"   0| 300| 512|  -8| 112|-896|   0|   0|" + //2
												"   0| 192| 320|-264|-240|   0|   0|   0|" + //3
												"   0|  12|  88|-256|-126|   0|   0|   0|" + //4
												"   0|  86| 120|  -8|   6|   4|   0|   0|" + //5
												"   0|  98| 128|  32|   8|   4|   0|   0|" + //6
												"   0|   0|   0|   0|   0|   0|   0|   0|" + //7
												"   0|   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene15Path = "5,5|6,5|6,4|6,3|6,2|5,2|5,3|4,3|3,3|2,3|2,4|2,5";


	//16

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6
	public static string Scene16 = "9|9|7|1|4$  0|   9|   9|   9|   9|   9|   9|   9|   0|"+
											"   9|   1|   1|   6|   1|   1|   5|  -1|   9|" +
											"   9|   1|   5|   1|   1|   9|   9|   9|   0|" +
											"   9|   1|   7|   3|   1|   9|   0|   0|   0|" +
											"   9|   9|   1|   1|   6|   9|   0|   0|   0|" +
											"   0|   0|   9|   1|   1|   9|   9|   0|   0|" +
											"   0|   0|   0|   9|  -2|   9|   0|   0|   0|" +
											"   0|   0|   0|   0|   9|   9|   0|   0|   0|" +
											"   0|   0|   0|   0|   0|   0|   0|   0|   0|";

	//dadoUp/dadoLeft/dadoForward		          //0    1    2    3    4    5    6
	public static string Scene16Numbers = "1|4|5$   0|   0|   0|   0|   0|   0|   0|   0|   0|"+
												"   0| 500| 250| 125|  25|   5|   5|   0|   0|" +
												"   0| 275|   1|  25|  75|   0|   0|   0|   0|" +
												"   0| 100| 125| 125| 250|   0|   0|   0|   0|" +
												"   0|   0|  25|  25| 275|   0|   0|   0|   0|" +
												"   0|   0|   0| 125|   1|   0|   0|   0|   0|" +
												"   0|   0|   0|  16|   0|   0|   0|   0|   0|" +
												"   0|   0|   0|   8|  25|   0|   0|   0|   0|" +
												"   0|   0|   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene16Path = "1,6|1,5|1,4|1,3|2,3|2,2|3,2|3,3|3,4|4,4|5,4|6,4";



	//division

	//18

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    
	public static string Scene17 = "9|9|6|2|0$  0|   0|   0|   0|   0|   0|   9|   0|   0|" +
											"   0|   9|   9|   9|   9|   9|   1|   9|   0|" +
											"   9|  -2|   1|   3|   1|   6|  -1|   9|   0|" +
											"   0|   9|   1|   1|   5|   5|   1|   9|   0|" +
											"   0|   9|   3|   5|   8|   1|   1|   9|   0|" +
											"   0|   9|   1|   1|   1|   6|   4|   9|   0|" +
											"   0|   9|   7|   1|   8|   1|   1|   5|   9|" +
											"   0|   9|   1|   9|   9|   9|   9|   9|   0|" +
											"	0|   0|   9|   0|   0|   0|   0|   0|   0|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene17Numbers = "25|5|6$  0|   0|   0|   0|   0|   0|   0|   0|   0|" +
												"   0|   0|   0|   0|   0|   0| 130|   0|   0|" +
												"   0|   0|  50|  25|  25|  30|   0|   0|   0|" +
												"   0|   0|  16|   8| 750|   5|  25|   0|   0|" +
												"   0|   0|   4|   1|   6| 150|  64|   0|   0|" +
												"   0|   0|  27|   8|   1| 750|  32|   0|   0|" +
												"   0|   0|  44|  32|   8|   4| 256| 512|   0|" +
												"   0|   0|  13|   0|   0|   0|   0|   0|   0|" +
												"   0|   0|   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene17Path = "2,5|3,5|4,5|5,5|4,4|4,3|2,4|2,3|2,2";


	//18

	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    
	public static string Scene18 = "7|7|5|1|0$   0|   9|   9|   9|   9|   9|   0|"+
											 "   9|   1|   1|   1|   5|  -1|   9|" +
											 "   9|   1|   1|   1|   1|   5|   9|" +
											 "   9|   3|   1|   6|   1|   1|   9|" +
											 "   9|   1|   1|   1|   1|   1|   9|" +
											 "   9|  -2|   1|   3|   1|   1|   9|" +
											 "   0|   9|   9|   9|   9|   9|   0|";

	//dadoUp/dadoLeft/dadoForward				  //0    1    2    3    4    5    6
	public static string Scene18Numbers = "4|4|2$    0|   0|   0|   0|   0|   0|   0|" +
												 "   0| 256|  32| 128|   8|   0|   0|" +
											 	 "   0|  16|   8|  64|  16|   8|   0|" +
												 "   0|   4|  32| 512|   2|  64|   0|" +
												 "   0|  12|   8|   8|   6|  32|   0|" +
												 "   0|   0|  32|   8|   4| 256|   0|" +
												 "   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene18Path = "1,4|2,4|2,3|3,3|4,3|3,4|3,2|2,2|3,1|4,1";



	//19

	//filas|columnas|posxini|posyini|imgtut	   //0    1    2    3    4    5    6
	public static string Scene19 = "9|8|6|5|0$   9|   1|   1|   1|   1|   3|   9|   0|" + //0
											 "   8|   1|   1|   8|   1|   1|   1|   9|" +
											 "   6|   1|   1|   4|   1|   1|  -2|   9|" +
											 "   1|   1|   1|   6|   1|   9|   9|   0|" +
											 "   1|   3|   1|   1|   1|   9|   9|   0|" +
											 "   1|   1|   8|   1|   1|   5|  -1|   9|" +
											 "   8|   8|   1|   1|   1|   5|   1|   9|" +
											 "   9|   1|   1|   6|   1|   5|   9|   0|" +
											 "   0|   9|   9|   9|   9|   9|   0|   0|";

	//dadoUp/dadoLeft/dadoForward		          //0    1    2    3    4    5    6
	public static string Scene19Numbers = "1|1|1$    0|  90| 128| 600|-172|  16|   0|   0|" + //0
												 "  32| 256| 360|-508|-520|   8|   2|   0|" + //1
												 " 256| 300| 512|   4| 124|  -4|   0|   0|" + //2
												 " 200| 192| 320| 512|   2|   0|   0|   0|" + //3
												 "  16| 128| 250| 310|   8|   0|   0|   0|" + //4
												 " 160|  64|  16|   4|   2|   2|   0|   0|" + //5
												 " 128|  32|   8|   4|   4|   3|   1|   0|" + //6
												 "   4|  16|  30|   4|   6|   5|   3|   0|" + //7
												 "   0|   0|   0|   0|   0|   0|   0|   0|";

	public static string Scene19Path = "5,5|5,4|5,3|6,3|6,2|6,1|6,0|5,1|4,1|3,1|3,2|3,3|2,3|1,3|2,4|2,5";


	//20
	//filas|columnas|posxini|posyini|imgtut	  //0    1    2    3    4    5    6    7    8 
	public static string Scene20 = "8|9|4|1|0$  1|   1|   1|   1|   1|   1|   1|   1|   0|" +
											"   1|   7|   1|   6|  -1|   6|   8|   1|   0|" +
											"   1|   1|   1|   4|   6|   1|   1|   1|   0|" +
											"   1|   1|   1|   1|   5|   1|   1|   1|   0|" +
											"   1|   1|   1|   1|   7|   3|   1|   1|   0|" +
											"   1|   1|   5|   7|   1|   1|   8|   1|   0|" +
											"   1|  -2|   1|   8|   3|   4|   1|   1|   0|" +
											"   1|   1|   1|   8|   1|   1|   1|   1|   0|";

	//filas|columnas|posxini|posyini|imgtut	          //0    1    2    3    4    5    6    7    8  
	public static string Scene20Numbers = "30|20|10$   30|   45|   25|  60|  40|   4|   2|   3|   0|" +
													" -25|  -30|   20|  50|   0| -50|   1|   4|   0|" +
													" -30|  -50|  -70|   5| -20|  60|   5|  -1|   5|" +
													"  40|  -20|  -30| -10|   1|   4|   5|   8|   9|" +
													"  35|  340|   20|   1| -20|   2|  34|   9|  16|" +
													"   9|-2400|   56|  43|  19|   3| -47|  17|  34|" +
													"   1|    0|-1120|  13|  30| -17|  41| -21|  -5|" +
													"   2|    3|  259|  60| -10| -36|  45|   5|   9|";

	public static string Scene20Path = "1,3|2,3|1,2|1,1|2,1|3,1|3,2|4,2|3,3|2,4|3,4|4,4|1,5|1,6|4,5|5,5|5,6|6,5|6,4|6,3|5,3|5,2|6,2";


    public enum CellColors {None, White, Yellow, Blue, Red, Green, Purple, Orange, GreenBlue, GreenYellow, PurpleBlue, PurpleRed, OrangeRed, OrangeYellow};
    public static CellColors CellColor = CellColors.White;

    public static CellColors getColor(CellColors colorA, CellColors colorB)
    {

        switch (colorA)
        {
            case CellColors.White:
                switch (colorB)
                {
                    case CellColors.Yellow: return CellColors.Yellow;
                    case CellColors.Blue: return CellColors.Blue;
                    case CellColors.Red: return CellColors.Red;
                    case CellColors.Green: return CellColors.Green;
                    case CellColors.Purple: return CellColors.Purple;
                    case CellColors.Orange: return CellColors.Orange;
                    case CellColors.GreenBlue: return CellColors.GreenBlue;
                    case CellColors.GreenYellow: return CellColors.GreenYellow;
                    case CellColors.PurpleBlue: return CellColors.PurpleBlue;
                    case CellColors.PurpleRed: return CellColors.PurpleRed;
                    case CellColors.OrangeRed: return CellColors.OrangeRed;
                    case CellColors.OrangeYellow: return CellColors.OrangeYellow;
                }
                break;
            case CellColors.Yellow:
                switch (colorB)
                {
                    case CellColors.White: return CellColors.Yellow;
                    case CellColors.Blue: return CellColors.Green;
                    case CellColors.Red: return CellColors.Orange;
                    case CellColors.Green: return CellColors.GreenYellow;
                    case CellColors.Orange: return CellColors.OrangeYellow;
                }
                break;
            case CellColors.Blue:
                switch (colorB)
                {
                    case CellColors.White: return CellColors.Blue;
                    case CellColors.Yellow: return CellColors.Green;
                    case CellColors.Red: return CellColors.Purple;
                    case CellColors.Green: return CellColors.GreenBlue;
                    case CellColors.Purple: return CellColors.PurpleBlue;
                }
                break;
            case CellColors.Red:
                switch (colorB)
                {
                    case CellColors.White: return CellColors.Red;
                    case CellColors.Yellow: return CellColors.Orange;
                    case CellColors.Blue: return CellColors.Purple;
                    case CellColors.Purple: return CellColors.PurpleRed;
                    case CellColors.Orange: return CellColors.OrangeRed;
                }
                break;
            case CellColors.Green:
                switch (colorB)
                {
                    case CellColors.Yellow: return CellColors.GreenYellow;
                    case CellColors.Blue: return CellColors.GreenBlue;
                    case CellColors.White: return CellColors.Green;
                }
                break;
            case CellColors.Purple:
                switch (colorB)
                {
                    case CellColors.Blue: return CellColors.PurpleBlue;
                    case CellColors.Red: return CellColors.PurpleRed;
                    case CellColors.White: return CellColors.Purple;
                }
                break;
            case CellColors.Orange:
                switch (colorB)
                {
                    case CellColors.Yellow: return CellColors.OrangeYellow;
                    case CellColors.Red: return CellColors.OrangeRed;
                    case CellColors.White: return CellColors.Orange;
                }
                break;
        }
        return CellColors.None;
    }
}
