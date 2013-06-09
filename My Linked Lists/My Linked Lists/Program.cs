using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList MyLinkedList = new LinkedList();

            CreateLinkedList(MyLinkedList);
            

        }

        

       

        private static void CreateLinkedList(LinkedList MyLinkedList)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Please enter the elements of a Linked List, \np to print, \nl to get length, \nc to make circular,\nn to get nth node from last, \nq to exit.");
           
            while (true)
            {
                 String input = Console.ReadLine();
                  switch (input)
                    {
                        case "c":
                            {
                                int l = MyLinkedList.GetLength();
                                if (l == 0)
                                {
                                    Console.WriteLine("Cant create circular linked list from empty list");

                                }
                                else
                                {
                                    Console.WriteLine("Enter a node number between 1 and " + l);
                                    int i = Convert.ToInt32(Console.ReadLine());

                                    if ((i >= 1) && (i <= l))
                                    {
                                        MyLinkedList.MakeCircular(i);
                                    }
                                }
                                // MyLinkedList.Print();

                                break;
                            }
                      case "p":
                            {
                                MyLinkedList.Print();
                              
                                break;
                            }
                      case "i":
                            {
                               //intersect 2 linked list at given node in 1 tail of 2nd should point to given node of 1

                                break;
                            }
                      case "cw?":
                            {
                                //where do cyclicals meet?
                                break;
                            }
                      case "r":
                            {
                                MyLinkedList.Reverse();
                                break;
                            }
                      case "c?":
                            {
                               bool Cyclical= MyLinkedList.IsCyclical();
                                String str = "Not Cyclical";
                                if (Cyclical)
                                {
                                    str = " IS Cyclical";
                                }
                                Console.WriteLine(str);
                                break;
                            }
                      case "n":
                            {
                                Console.WriteLine("Enter a value of the node from end.");
                                int n = Convert.ToInt32(Console.ReadLine());
                                MyLinkedList.GetNthFromLast(n);

                                break;
                            }
                      case "l":
                            {
                                int len = MyLinkedList.GetLength();
                                if (len==0)
                                {
                                    Console.WriteLine("List is Empty.Length is 0");
                                }
                                else
                                {
                                    Console.WriteLine("Length: " + len);   
                                }
                                
                                break;
                            }
                      case "q": return;
                      case "": break;
                      default:
                        //    {
                                MyLinkedList.AddHead(Convert.ToInt32(input));
                          break;
                         //   }
                    }
            }
          
        }
    }
}
