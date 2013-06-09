using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Linked_Lists
{
    class LinkedList
    {

        public Node head;
        public Node tail;

          public LinkedList()
          {
              head = null;
              tail = null;
          }

        public void AddHead(int data)
       {
           Node temp = new Node(data);
            //Console.WriteLine("Added New node with data" + temp.Data);
            if (head == null)
            {
                head = temp;
                tail = head;
            }
            else
            {
                temp.next = head;
                head = temp;
            }
            return;
       }

        public void AddTail(int data)
        {
            Node temp = new Node(data);

            tail.next = temp;
            tail = temp;

            return;
        }

        internal void Print()
        {
            //throw new NotImplementedException();
            if (this.head == null)
            {
                Console.WriteLine("List is Empty.");
            }
            else
            {
                Node temp = this.head;
                while (temp !=null)
                {
                   
                    Console.Write(temp.Data + " ");// can try to make it a behaviour of the node something like temp.printdata()
                    if (temp==tail)
                    {
                        break;
                    }
                    else
                    {
                        temp = temp.next; 
                    }
                     
                    
                   
                    
                    //TODO add logic to not print beyond tail
                }
                Console.WriteLine();
            }
                                
        }



        internal int GetLength()
        {
            //throw new NotImplementedException();
            Node temp = this.head;
            int i = 0;
            while (temp != null)
            {
                i++;
                if (temp == tail)
                {
                    break;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return i;
        }

        internal void MakeCircular(int i)
        {
            //throw new NotImplementedException();
            int t = 1;
            Node temp = head;
            while(t!=i)
            {
                temp = temp.next;
                t++;
            }
            tail.next = temp;
            Console.WriteLine(tail.next.Data);


        }

        internal void GetNthFromLast(int n)
        {
            //throw new NotImplementedException();
            if (head==null)
            {
                Console.WriteLine("List is empty.");
                return;
            }
            int l = this.GetLength();

            if (n>l)
            {
                Console.WriteLine("List is shorter than node.");
                return; 
            }

            Node front = head;
            Node back = head;

            int i;
            for (i=0;i<n;i++)
            {
                front = front.next;
            }
            while(front!=null)
            {
                front = front.next;
                back = back.next;
            }
            Console.WriteLine("The "+n+" value is "+back.Data);
        }

        internal bool IsCyclical()
        {
            //throw new NotImplementedException();

            Node slow = head;
            Node fast = head.next;
            while(true)
            {
                if (fast == null || fast.next == null)
                    return false;
                if (fast.next == slow || fast == slow)
                    return true;
                slow = slow.next;
                fast = fast.next.next;

            }

        }

        internal void Reverse()
        {
            //throw new NotImplementedException();
            if(head==null||head.next==null)
            {
                return;
            }
            Node back = null;
            Node mid = head;
            Node front = head.next;
            tail = null;
            while(true)
            {
                //Console.WriteLine("mis is "+mid.Data);
                mid.next = back;

                back = mid;
                if(tail ==null)
                {
                    tail = mid;
                }
                mid = front;

                front = front.next;
                if(front==null)
                {
                    mid.next = back;
                    head = mid;
                    return;
                }

            }
        }
    }
}
