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
            LinkedList LinkedList2 = new LinkedList();
            CreateLinkedList(MyLinkedList,LinkedList2);
            

        }

        

       

        private static void CreateLinkedList(LinkedList MyLinkedList, LinkedList LinkedList2)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Please enter the elements of a Linked List, \np to print, \nl to get length, \nc to make circular,\nci to create intersecting lists,\ni? to check if 2 linked lists intersect,\nn to get nth node from last,\nP? Is List a Palindrome? \nq to exit.");
           
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
                      case "dd":
                            {
                                //deduplicate

                                break;
                            }
                      case "z":
                            {
                                //zip merge
                                Node mid = GetMiddleNode(MyLinkedList);
                                LinkedList2.head = mid.next;
                                mid.next = null;
                                LinkedList2.Reverse();
                                LinkedList2.Print();
                                bool alt = true;
                                mid = zipMerge(MyLinkedList.head, LinkedList2.head,alt);
                                MyLinkedList.head = mid;
                                MyLinkedList.Print();
                                break;
                            }
                      case "a":
                            {
                                //create additional linked list
                                LinkedList2 = MakeNewLinkedList(LinkedList2);
                                break;
                            }
                      case "sm":
                            {
                                //create additional linked list
                                LinkedList2.head = SortedMerge(MyLinkedList.head,LinkedList2.head);
                                LinkedList2.Print();
                                break;
                            }
                      case "ci":
                            {
                                //create interecting list
                                //LinkedList LinkedList2 = new LinkedList();

                                LinkedList2 = MakeNewLinkedList(LinkedList2);

                                IntersectLists(MyLinkedList, LinkedList2);
                                

                                break;
                            }
                      case "i?":
                            {
                               //DO 2 linked lists intersect if so where

                                int len1 = MyLinkedList.GetLength();
                                int len2 = LinkedList2.GetLength();

                                int diff;
                                Node start1 = MyLinkedList.head;
                                Node start2 = LinkedList2.head;

                                if (len1 >= len2)
                                {
                                    diff = len1 - len2;
                                    for(int n=0;n<diff;n++)
                                    {
                                    start1=start1.next;
                                    }
                                }
                                else
                                {
                                    diff=len2-len1;
                                     for(int n=0;n<diff;n++)
                                    {
                                    start2=start2.next;
                                    }
                                }
                                
                                while(start1 !=null)
                                {
                                if (start1 == start2)
                                {
                                    Console.WriteLine("Lists intersect at :"+start1.Data);
                                    break;
                                }
                                else
                                {
                                    start1=start1.next;
                                    start2=start2.next;
                                }
                                

                                }
                                Console.WriteLine("Lists do not intersect.");

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
                      case "add":
                            {
                                //add 2 linked lists
                                LinkedList result = AddLinkedLists(MyLinkedList.head, LinkedList2.head);
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

        private static LinkedList AddLinkedLists(Node node1, Node node2)
        {
            //throw new NotImplementedException();
            LinkedList List3 = new LinkedList();
            if (node1==null)
            {
                List3.head = node2;
                return List3;
            }

            if(node2==null)
            {
                List3.head = node1;
                return List3;
            }
            //LinkedList List3= new LinkedList();
            int carry =0;
            int addValue=0;
            Node temp1=node1;
            Node temp2=node2;

           while ((temp1.next !=null) ||(temp2.next!=null))
                {

                int value=carry;

                if(temp1!=null) 
                {
                value = value +temp1.Data;
                }
                if(temp2!=null)
                {
                value =value+temp2.Data;
                }
                addValue=value % 10;

                if (value >= 10)
                {
                    carry = 1;
                }
                else carry = 0;

                List3.AddTail(addValue);

                }
           return List3;
         }

        private static Node SortedMerge(Node node1, Node node2)
        {
            //throw new NotImplementedException();
            Node result = null;
            //guardclause
            if(node1 ==null)
            {
                return node2;
            }
            if(node2==null)
            {
                return node1;
            }
            Console.WriteLine(node1.Data + " " + node2.Data);
            if(node1.Data < node2.Data)
            {
                result = node1;
                result.next = SortedMerge(node1.next, node2);
            }
            else
            {
                result = node2;
                result.next = SortedMerge(node1, node2.next);
            }
            return result;
        }

        private static Node zipMerge(Node node1, Node node2,bool alt)
        {
            //throw new NotImplementedException();
            Node result = null;
            Console.WriteLine(node1.Data + " " + node2.Data);
            //guardclause
            if (node1 == null)
            {
                return node2;
            }
            if (node2 == null)
            {
                return node1;
            }
            
            if (alt)
            {
                result = node1;
                alt = false;
                result.next = zipMerge(node1.next, node2,alt);
            }
            else
            {
                result = node2;
                alt = true;
                result.next = zipMerge(node1, node2.next,alt);
            }
            return result;
        }

        private static void IntersectLists(LinkedList MyLinkedList, LinkedList LinkedList2)
        {
            //throw new NotImplementedException();
            int i;
            i = MyLinkedList.GetLength();
            Console.WriteLine("Enter a number between 1 and " + i);
            int nodenumber = Convert.ToInt32(Console.ReadLine());
            i = 0;
            Node temp = MyLinkedList.head;

            while (i < nodenumber)
            {
                temp = temp.next;
                i++;
            }
            LinkedList2.tail.next = temp;
            LinkedList2.tail = MyLinkedList.tail;

            LinkedList2.Print();
        }

        private static LinkedList MakeNewLinkedList(LinkedList LinkedList2)
        {
            //throw new NotImplementedException();
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

            LinkedList2.Print();
            return LinkedList2;
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
