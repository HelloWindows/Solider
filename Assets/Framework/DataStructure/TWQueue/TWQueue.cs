/*******************************************************************
 * FileName: TWQueue.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework {
    namespace DataStructure {
        public class TWQueue<T> {
            public int Count { get; private set; }
            private Node head;
            private Node tail;

            public TWQueue() {
                Count = 0;
                head = null;
                tail = null;
            } // end TWQueue

            public void Enqueue(T obj) {
                Count++;
                if (null == head) {
                    head = new Node(obj, null, null);
                    tail = head;
                    return;
                } // end if
                if (null == head.next) {
                    tail = new Node(obj, head, null);
                    head.next = tail;
                    return;
                } // end if
                Node node = new Node(obj, tail, null);
                tail.next = node;
                tail = node;
            } // end Enqueue

            public void EnqueueRev(T obj) {
                Count++;
                if (null == tail) {
                    tail = new Node(obj, null, null);
                    head = tail;
                    return;
                } // end if
                if (null == tail.last) {
                    head = new Node(obj, null, tail);
                    tail.last = head;
                    return;
                } // end if
                Node node = new Node(obj, null, head);
                head.last = node;
                head = node;
            } // end EnqueueRev

            public T Dequeue() {
                if (Count <= 0 || null == head) return default(T);
                // end if
                Count--;
                T t = head.obj;
                head = head.next;
                head.last = null;
                return t;
            } // end Dequeue

            public T DequeueRev() {
                if (Count <= 0 || null == head) return default(T);
                // end if
                Count--;
                T t = tail.obj;
                tail = tail.last;
                tail.next = null;
                return t;
            } // end DequeueRev

            public T Peek() {
                if (Count <= 0 || null == head) return default(T);
                // end if
                return head.obj;
            } // end Peek

            public T PeekRev() {
                if (Count <= 0 || null == head) return default(T);
                // end if
                return tail.obj;
            } // end PeekRev

            public bool Contains(T obj) {
                Node node = head;
                while (null != node) {
                    if (obj.Equals(node.obj)) return true;
                    // end if
                    node = node.next;
                } // end whil
                return false;
            } // end Contains

            private class Node {
                public T obj { get; set; }
                /// <summary>
                /// 上一个
                /// </summary>
                public Node last { get; set; }
                /// <summary>
                /// 下一个
                /// </summary>
                public Node next { get; set; }

                public Node(T obj, Node last, Node next) {
                    this.obj = obj;
                    this.last = last;
                    this.next = next;
                } // end Node
            } // end class Node
        } // end class TWQueue 
    } // end namespace DataStructure
} // end namespace Framework