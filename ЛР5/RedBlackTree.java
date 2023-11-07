class Node_ {
	int data; // ключ
	Node_ parent; // указатель на родителя
	Node_ left; // указатель на левого потомка
	Node_ right; // указатель на правого потомка
	int color; // 1 . красный, 0 . черный
}


// класс RedBlackTree реализует операции в Red Black Tree
public class RedBlackTree {
	private Node_ root;
	private Node_ TNULL;

	private void preOrderHelper(Node_ node) {
		if (node != TNULL) {
			System.out.print(node.data + " ");
			preOrderHelper(node.left);
			preOrderHelper(node.right);
		} 
	}

	private void inOrderHelper(Node_ node) {
		if (node != TNULL) {
			inOrderHelper(node.left);
			System.out.print(node.data + " ");
			inOrderHelper(node.right);
		} 
	}

	private void postOrderHelper(Node_ node) {
		if (node != TNULL) {
			postOrderHelper(node.left);
			postOrderHelper(node.right);
			System.out.print(node.data + " ");
		} 
	}

	private Node_ searchTreeHelper(Node_ node, int key) {
		if (node == TNULL || key == node.data) {
			return node;
		}

		if (key < node.data) {
			return searchTreeHelper(node.left, key);
		} 
		return searchTreeHelper(node.right, key);
	}

	// исправление rbtree после операции удаления
	private void fixDelete(Node_ x) {
		Node_ s;
		while (x != root && x.color == 0) {
			if (x == x.parent.left) {
				s = x.parent.right;
				if (s.color == 1) {
					// case 3.1
					s.color = 0;
					x.parent.color = 1;
					leftRotate(x.parent);
					s = x.parent.right;
				}

				if (s.left.color == 0 && s.right.color == 0) {
					// case 3.2
					s.color = 1;
					x = x.parent;
				} else {
					if (s.right.color == 0) {
						// case 3.3
						s.left.color = 0;
						s.color = 1;
						rightRotate(s);
						s = x.parent.right;
					} 

					// case 3.4
					s.color = x.parent.color;
					x.parent.color = 0;
					s.right.color = 0;
					leftRotate(x.parent);
					x = root;
				}
			} else {
				s = x.parent.left;
				if (s.color == 1) {
					// case 3.1
					s.color = 0;
					x.parent.color = 1;
					rightRotate(x.parent);
					s = x.parent.left;
				}

				if (s.right.color == 0 && s.right.color == 0) {
					// case 3.2
					s.color = 1;
					x = x.parent;
				} else {
					if (s.left.color == 0) {
						// case 3.3
						s.right.color = 0;
						s.color = 1;
						leftRotate(s);
						s = x.parent.left;
					} 

					// case 3.4
					s.color = x.parent.color;
					x.parent.color = 0;
					s.left.color = 0;
					rightRotate(x.parent);
					x = root;
				}
			} 
		}
		x.color = 0;
	}


	private void rbTransplant(Node_ u, Node_ v) { // пересадка узла (ребенка) при удалении
		if (u.parent == null) {
			root = v;
		} else if (u == u.parent.left){
			u.parent.left = v;
		} else {
			u.parent.right = v;
		}
		v.parent = u.parent;
	}

	private void deleteNodeHelper(Node_ node, int key) {
		// найти узел, содержащий ключ
		Node_ z = TNULL;
		Node_ x, y;
		while (node != TNULL){
			if (node.data == key) {
				z = node;
			}

			if (node.data <= key) {
				node = node.right;
			} else {
				node = node.left;
			}
		}

		if (z == TNULL) {
			System.out.println("Такого ключа нет");
			return;
		} 

		y = z;
		int yOriginalColor = y.color; // сохраняем цвет удаляемого элемента
		if (z.left == TNULL) { // если левый ребенок - NULL
			x = z.right;
			rbTransplant(z, z.right); // пересадка правого ребенка на место удаляемого элемента
		} else if (z.right == TNULL) { // если правый ребенок - NULL
			x = z.left;
			rbTransplant(z, z.left); // пересадка левого ребенка на место удаляемого элемента
		} else {
			y = minimum(z.right); // минимум правого поддерева
			yOriginalColor = y.color; // сохраняем цвет минимального элемента правого поддерева
			x = y.right; // удаляемый элемент	
			if (y.parent == z) { // если y является ребенком удаляемого элемента
				x.parent = y; // родитель x = y
			} else {
				rbTransplant(y, y.right); // пересадка правого ребенка y на место y 
				y.right = z.right;
				y.right.parent = y;
			}

			rbTransplant(z, y); // пересадка y на место удаляемого элемента
			y.left = z.left;
			y.left.parent = y;
			y.color = z.color;
		}
		if (yOriginalColor == 0){ // если цвет черный
			fixDelete(x);
		}
	}
	
	// исправление rbtree после операции вставки
	private void fixInsert(Node_ k){
		Node_ u;
		while (k.parent.color == 1) { // пока родитель красный
			if (k.parent == k.parent.parent.right) { // если это левый дочерний элемент
				u = k.parent.parent.left; // дядя
				if (u.color == 1) { // 
					// case 3.1
					u.color = 0; // черный
					k.parent.color = 0; // черный
					k.parent.parent.color = 1; // красный
					k = k.parent.parent; // назначить как новый узел
				} else {
					if (k == k.parent.left) {
						// case 3.2.2
						k = k.parent;
						rightRotate(k); // повернуть вправо 
					}
					// case 3.2.1
					k.parent.color = 0; // черный
					k.parent.parent.color = 1; // красный
					leftRotate(k.parent.parent); // повернуть влево
				}
			} else {
				u = k.parent.parent.right; // дядя

				if (u.color == 1) {
					// зеркальный case 3.1
					u.color = 0; // черный
					k.parent.color = 0; // черный
					k.parent.parent.color = 1; // красный
					k = k.parent.parent;	
				} else {
					if (k == k.parent.right) {
						// зеркальный case 3.2.2
						k = k.parent;
						leftRotate(k);
					}
					// зеркальный case 3.2.1
					k.parent.color = 0; // черный
					k.parent.parent.color = 1; // красный
					rightRotate(k.parent.parent);
				}
			}
			if (k == root) {
				break;
			}
		}
		root.color = 0;
	}

	private void printHelper(Node_ root, String indent, boolean last) {
		// вывести древовидную структуру на экран
	   	if (root != TNULL) {
		   System.out.print(indent);
		   if (last) {
		      System.out.print("R----");
		      indent += "     ";
		   } else {
		      System.out.print("L----");
		      indent += "|    ";
		   }
            
           String sColor = root.color == 1?"RED":"BLACK";
		   System.out.println(root.data + "(" + sColor + ")");
		   printHelper(root.left, indent, false);
		   printHelper(root.right, indent, true);
		}
	}

	public RedBlackTree() {
		TNULL = new Node_();
		TNULL.color = 0;
		TNULL.left = null;
		TNULL.right = null;
		root = TNULL;
	}

	// Pre-Order обход
	// Node.Left Subtree.Right Subtree
	public void preorder() {
		preOrderHelper(this.root);
	}

	// Обход по порядку
	// Left Subtree . Node . Right Subtree
	public void inorder() {
		inOrderHelper(this.root);
	}

	// Post-Order обход
	// Left Subtree . Right Subtree . Node
	public void postorder() {
		postOrderHelper(this.root);
	}

	// поиск в дереве ключа k и возвращение соответствующего узла
	public Node_ searchTree(int k) {
		return searchTreeHelper(this.root, k);
	}

	// найти узел с минимальным ключом
	public Node_ minimum(Node_ node) {
		while (node.left != TNULL) {
			node = node.left;
		}
		return node;
	}

	// найти узел с максимальным ключом
	public Node_ maximum(Node_ node) {
		while (node.right != TNULL) {
			node = node.right;
		}
		return node;
	}

	// найти преемника заданного узла
	public Node_ successor(Node_ x) {
		// если правое поддерево не является нулевым, то преемником является самый левый узел в правом поддереве
		if (x.right != TNULL) {
			return minimum(x.right);
		}

		// иначе это самый младший предок x, чей левый ребенок также является предком x.
		Node_ y = x.parent;
		while (y != TNULL && x == y.right) {
			x = y;
			y = y.parent;
		}
		return y;
	}

	// найти предшественника заданного узла
	public Node_ predecessor(Node_ x) {
		// если левое поддерево не является нулевым, то предшественником является самый правый узел в левом поддереве
		if (x.left != TNULL) {
			return maximum(x.left);
		}

		Node_ y = x.parent;
		while (y != TNULL && x == y.left) {
			x = y;
			y = y.parent;
		}

		return y;
	}

	// повернуть влево в узле x
	public void leftRotate(Node_ x) {
		Node_ y = x.right;
		x.right = y.left;
		if (y.left != TNULL) {
			y.left.parent = x;
		}
		y.parent = x.parent;
		if (x.parent == null) {
			this.root = y;
		} else if (x == x.parent.left) {
			x.parent.left = y;
		} else {
			x.parent.right = y;
		}
		y.left = x;
		x.parent = y;
	}

	// повернуть вправо в узле x
	public void rightRotate(Node_ x) {
		Node_ y = x.left;
		x.left = y.right;
		if (y.right != TNULL) {
			y.right.parent = x;
		}
		y.parent = x.parent;
		if (x.parent == null) {
			this.root = y;
		} else if (x == x.parent.right) {
			x.parent.right = y;
		} else {
			x.parent.left = y;
		}
		y.right = x;
		x.parent = y;
	}

	// вставить ключ в дерево в соответствующее место
	// и исправить дерево
	public void insert(int key) {
		// Ordinary Binary Search Insertion
		Node_ node = new Node_();
		node.parent = null;
		node.data = key;
		node.left = TNULL;
		node.right = TNULL;
		node.color = 1; // новый узел должен быть красным

		Node_ y = null;
		Node_ x = this.root;

		while (x != TNULL) {
			y = x;
			if (node.data < x.data) {
				x = x.left;
			} else {
				x = x.right;
			}
		}

		// y родитель x
		node.parent = y;
		if (y == null) {
			root = node;
		} else if (node.data < y.data) {
			y.left = node;
		} else {
			y.right = node;
		}

		// если новый узел является корневым узлом, просто возвращаем
		if (node.parent == null){
			node.color = 0;
			return;
		}

		// если прорадители равны нулю, просто возвращаем
		if (node.parent.parent == null) {
			return;
		}

		// исправляем дерево
		fixInsert(node);
	}

	public Node_ getRoot(){
		return this.root;
	}

	// удалить узел из дерева
	public void deleteNode(int data) {
		deleteNodeHelper(this.root, data);
	}

	// вывести структуру дерева
	public void prettyPrint() {
        printHelper(this.root, "", true);
	}
}