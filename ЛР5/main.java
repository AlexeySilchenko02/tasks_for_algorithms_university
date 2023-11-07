import java.util.Scanner;

public class main {   
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Выберите опцию: 1 - бинарное дерево, 2 - красно-черное дерево");
        int act = in.nextInt();

        if (act == 1) {
            Tree tree = new Tree();

            // вставляем узлы в дерево:
            tree.insertNode(20);
            tree.insertNode(15);
            tree.insertNode(8);
            tree.insertNode(12);
            tree.insertNode(23);
            tree.insertNode(9);
            tree.insertNode(7);
            tree.insertNode(4);
            // tree.insertNode(11);
            // tree.insertNode(3);
            // tree.insertNode(1);

            // отображение дерева:
            tree.printTree();
            while (true) {
                System.out.println("Выберите действие: 1 - поиск, 2 - вставка элемента, 3 - удаление элемента");
                int action = in.nextInt();

                if (action == 1) {
                    System.out.println("Введите элемент");
                    int el = in.nextInt();
                    Node foundNode = tree.findNodeByValue(el);
                    foundNode.printNode();
                }

                if (action == 2) {
                    System.out.println("Введите элемент");
                    int el = in.nextInt();
                    tree.insertNode(el);
                    tree.printTree();
                }

                if (action == 3) {
                    System.out.println("Введите элемент");
                    int el = in.nextInt();
                    tree.deleteNode(el);
                    tree.printTree();
                }
            }
        }

        if (act == 2) {
            RedBlackTree bst = new RedBlackTree();

            bst.insert(20);
            bst.insert(8);
            bst.insert(15);
            bst.insert(12);
            bst.insert(23);
            bst.insert(9);
            bst.insert(7);
            bst.insert(4);

            bst.prettyPrint();

            while (true) {
                System.out.println("Выберите действие: 1 - поиск, 2 - вставка элемента, 3 - удаление элемента");
                int action = in.nextInt();

                if (action == 1) {
                    System.out.println("Введите элемент");
                    int el = in.nextInt();
                    Node_ foundNode = bst.searchTree(el);
                    System.out.println("Элемент = " + foundNode);
                }

                if (action == 2) {
                    System.out.println("Введите элемент");
                    int el = in.nextInt();
                    bst.insert(el);
                    bst.prettyPrint();
                }

                if (action == 3) {
                    System.out.println("Введите элемент");
                    int el = in.nextInt();
                    bst.deleteNode(el);
                    bst.prettyPrint();
                }
            }

        }

    }
}