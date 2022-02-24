using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tool_Library
{
	/*
	 * Node class to store the connections for each member in the bstree
	 */
	class BSNode
	{
		iMember item; //member
		BSNode lchild; //members left child
		BSNode rchild; //members right child
		public BSNode(iMember item)
		{
			this.Item = item;
			lchild = null;
			rchild = null;
		}

		public IComparable Item
		{
			get { return item; }
			set { item = (iMember)value; }
		}

		public BSNode LChild
		{
			get { return lchild; }
			set { lchild = value; }
		}

		public BSNode RChild
		{
			get { return rchild; }
			set { rchild = value; }
		}
		public override string ToString() {
			return item.ToString();
		}
		public bool Lcheck()
		{
			return (lchild != null);
		}
		public bool Rcheck()
		{
			return (rchild != null);
		}
	}
	/*
	 * ImemberCollection implmentation as A BStree
	 */
	class BSTree : iMemberCollection
	{
		private BSNode root; //starting node in the tree
		private int count = 0; //amount of members in the tree
		private int ai = 0; //index for creating a sorted array

        public int Number { get { return count; } }
		
        public BSTree()
		{
			root = null;
		}
		/*
		 * Search for a member within the tree
		 * takes: imember: to search tree for
		 * returns bool: true if member is found false otherwise
		 */
		public bool search(iMember item)
		{
			return search(item, root);
		}
		/*
        * search the member tree
        * takes: string[], with firstname, lastname, phone number as strings to search the tree for in a single user
        *		BSnode, current node ni the tree to search
        *returns imember if a match is found, else null if none is found
        */
		private iMember search(string[] values, BSNode r)
		{
			//check if node passed is not null
			if (r != null)
			{
				//check if rge node and the passed string are the same name or phone number
				Member check = (Member)r.Item;
				if (check.search_string(values) == true) {
					//if true return the member
					return check;
				}
				else {
					//else check the other branches of the tree 
					//a log(n) approch can not be used here due the variation that exists 
					//within the sttring[], since it could just be aphone number or first name
					//this means that trimming the tree via, left or right child is impossable without 
					//breaking the searching for phone numbers or fisrt names
					iMember L = search(values, r.LChild);
					iMember R = search(values, r.RChild);
					if (L != null)
                    {
						return L;
                    } if (R != null)
                    {
						return R;
                    }
					
				}
			}
			return null;
		}
		/*
        * search the Bstree for a given user given at least a firstname, lastname or phone number
        * takes string[], containing firstname lastname and phone number, to search the tree for a member with the same varibles
        * returns imember if a user is found else null
        */
		public iMember search(string[] values) 
        {
			//BSNode root_s = this.root;
			if (root != null)
			{
				Member check = (Member)root.Item;
				if (check.search_string(values) == true){
					return check;
                }
                else
                {
					iMember L = search(values, root.LChild);
					iMember R = search(values, root.RChild);
					if (L != null)
					{
						return L;
					}
					if (R != null)
					{
						return R;
					}
				}
			}
			return null;
			
		}
		/*
		 * Search for a member within the tree
		 * takes: imember: to search tree for
		 *		BSNode: to start search from
		 * returns bool: true if member is found false otherwise
		 */
		private bool search(iMember item, BSNode r)
		{
			if (r != null)
			{
				if (item.CompareTo(r.Item) == 0)
					return true;
				else
					if (item.CompareTo(r.Item) < 0)
					return search(item, r.LChild);
				else
					return search(item, r.RChild);
			}
			else
				return false;
		}
		/*
		 * add a new user to the search tree
		 * takes: imember: to add to the tree
		 */
		public void add(iMember item)
		{
			if (root == null) { 
				root = new BSNode(item);
				count++;
			}
			else
				Insert(item, root);
		}


		/*
		 * part of the add function that checks where to add the new member to the tree
		 * takes: imeber: member to add to tree
		 *		BSnond: node to check if member shoud be added beneth
		 */
		private void Insert(iMember item, BSNode ptr)
		{
			//check if the item to insert will be on the left side of the node
			if (item.CompareTo(ptr.Item) < 0)
			{
				//find bottom of the search tree to add new user
				if (ptr.LChild == null) { 
					ptr.LChild = new BSNode(item);
					count++;
				}
				else
					Insert(item, ptr.LChild);
			}
			else
			{
				//find the bottom of the right side of the search tree to add the new user
				if (ptr.RChild == null) { 
					ptr.RChild = new BSNode(item);
					count++;
				}
				else
					Insert(item, ptr.RChild);
			}
		}
		// there are three cases to consider:
		// 1. the node to be deleted is a leaf
		// 2. the node to be deleted has only one child 
		// 3. the node to be deleted has both left and right children
		public void delete(string[] arg_search)
        {
			iMember item = search(arg_search);
			if (item != null){
				delete(item);
				count--;
            }
        }
		public void delete(iMember item)
		{
			// search for item and its parent
			BSNode parent = null; // parent of toremove
			BSNode toremove = root; //node to edit
			//try and find the node to edit, terminating when the bottom or node is found
			while ((toremove != null) && (item.CompareTo(toremove.Item) != 0))
			{
				parent = toremove;
				if (item.CompareTo(toremove.Item) < 0) {
					toremove = parent.LChild;
				}
				else if (item.CompareTo(toremove.Item) != 0) {
					toremove = parent.RChild;
				}
			}
			if (toremove != null) // if the search was successful
			{
				// case 3: item has two children
				if ((toremove.LChild != null) && (toremove.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if (toremove.LChild.RChild == null) // a special case: the right subtree of toremove.LChild is empty
					{
						toremove.Item = toremove.LChild.Item;
						toremove.LChild = toremove.LChild.LChild;
					}
					else
					{
						BSNode p = toremove.LChild;
						BSNode pp = toremove; // parent of p
						while (p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						toremove.Item = p.Item;
						pp.RChild = p.LChild;
					}
				}
				else // cases 1 & 2: item has no or only one child
				{
					BSNode c;
					if (toremove.LChild != null)
						c = toremove.LChild;
					else
						c = toremove.RChild;

					// remove node to remove
					if (toremove == root) //need to change root
						root = c;
					else
					{
						if (toremove == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
				}

			}
		}

		/*
		 * pre order traverse to print out the mebers in the r
		 */
		private void PreOrderTraverse(BSNode root)
		{
			if (root != null)
			{
				Console.Write(root.Item);
				PreOrderTraverse(root.LChild);
				PreOrderTraverse(root.RChild);
			}
		}

		public void InOrderTraverse()
		{
			Console.Write("InOrder: ");
			InOrderTraverse(root);
			Console.WriteLine();
		}

		private void InOrderTraverse(BSNode root)
		{
			if (root != null)
			{
				InOrderTraverse(root.LChild);
				Console.Write(root.Item);
				InOrderTraverse(root.RChild);
			}
		}


		private void PostOrderTraverse(BSNode root)
		{
			if (root != null)
			{
				PostOrderTraverse(root.LChild);
				PostOrderTraverse(root.RChild);
				Console.Write(root.Item);
			}
		}


		/*
		 * An in-order traversal was used to sort the array in oder of A-Z
		 */
        public iMember[] toArray()
        {
			Console.WriteLine(count);
			iMember[] array = new iMember[count];
			array=toArray(array,root);
			ai = 0;
			return array;

		}
		private iMember[] toArray(iMember[] array, BSNode root)
		{
			iMember member = null;
			if (root != null)
			{
				array=toArray(array,root.LChild);
				
				member = (iMember)root.Item;
				array[ai] = member;
				ai++;
				array = toArray(array,root.RChild);
				

			}
			return array;

		}
	}
}
