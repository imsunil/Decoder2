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
            Console.WriteLine("Please enter the elements of a Linked List, \np to print, \nl to get length, \nc to make circular,\nn to get nth node from last,\nP? Is List a Palindrome? \nq to exit.");
           
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
                      case "ci":
                            {
                                //create interecting list
                                LinkedList LinkedList2 = new LinkedList();
                                Console.WriteLine("Enter elements for 2nd lnked list, -1 to end.");
                                int i;
                                while (true)
                                {
                                    i = Convert.ToInt32(Console.ReadLine());
                                    if (i != -1)
                                    {
                                        LinkedList2.AddHead(i);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                                
                                i= MyLinkedList.GetLength();
                                Console.WriteLine("Enter a number between 1 and " +i);
                                int nodenumber = Convert.ToInt32(Console.ReadLine());
                                i =0;
                                Node temp = MyLinkedList.head;

                                while (i <= nodenumber)
                                {
                                    temp = temp.next;
                                    i++;
                                }
                                LinkedList2.tail.next = temp;
                                LinkedList2.tail = MyLinkedList.tail;

                                LinkedList2.Print();

                                break;
                            }
                      case "i":
                            {
                               //intersect 2 linked list at given node in 1 tail of 2nd should point to given node of 1

                                break;
                            }
                      case "P?":
                            {
                                //If a given linked list is simple palindrome
                                Node middleNode = GetMiddleNode(MyLinkedList);
                                
                                LinkedList MyLinkedList2 = new LinkedList();
                                MyLinkedList2.head = middleNode.next;
                                //MyLinkedList2.tail = middleNode.next;
                                //MyLinkedList2.Print();
                                MyLinkedList2.Reverse();

                                MyLinkedList.tail = middleNode;

                                middleNode.next = null;

                                bool isPalindrome = true;

                                isPalindrome = CheckforPalindrome(MyLinkedList.head, MyLinkedList2.head);

                                if (isPalindrome)
                                {
                                    Console.WriteLine("Linked List is a Palindrome.");
                                }
                                else
                                {
                                    Console.WriteLine("Linked List is not a Palindrome.");
                                }


                                MyLinkedList2.Reverse();
                                MyLinkedList2.Print();
                                MyLinkedList.tail.next = MyLinkedList2.head;
                                MyLinkedList.tail = MyLinkedList2.tail;


                                Console.WriteLine("The original Linked List is : ");
                                MyLinkedList.Print();


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

        private static bool CheckforPalindrome(Node head1, Node head2)
        {
            //guard clauses
            Node front = head1;
            Node temp = head2;

            Console.WriteLine("Starting Values are: " + front.Data + " " + temp.Data);
            bool isPalindrome = true;
            while (front != null)
            {
                if (front.Data != temp.Data)
                {
                    isPalindrome= false;
                    break;
                }
                front = front.next;
                temp = temp.next;
                if (temp == null)
                    break;
            }
            return isPalindrome;
        }

        private static Node GetMiddleNode(LinkedList MyLinkedList)
        {
            //throw new NotImplementedException();
            Node front = MyLinkedList.head;
            Node back = MyLinkedList.head;
            bool alt = true;
            while(front!=null)
            {
            if (alt)
            {
                front= front.next;
                alt = false;
            }
            else
            {
                front =front.next;
                back=back.next;
                alt = true;
            }
           // alt=false;
            }
            Console.WriteLine("Middle node is : "+back.Data);
            return back;
        }
    }
}
