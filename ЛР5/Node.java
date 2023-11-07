class Node {
   private int value; // ключ узла
   private Node leftChild; // Левый узел потомок
   private Node rightChild; // Правый узел потомок

   public void printNode() { // Вывод значения узла в консоль
       System.out.println(" Выбранный узел имеет значение :" + value);
   }

   public int getValue() {
       return this.value;
   }

   public void setValue(final int value) {
       this.value = value;
   }

   public Node getLeftChild() {
       return this.leftChild;
   }

   public void setLeftChild(final Node leftChild) {
       this.leftChild = leftChild;
   }

   public Node getRightChild() {
       return this.rightChild;
   }

   public void setRightChild(final Node rightChild) {
       this.rightChild = rightChild;
   }

//    @Override
//    public String toString() {
//         return "Node{" +
//                "value=" + value +
//                ", leftChild=" + leftChild +
//                ", rightChild=" + rightChild +
//                '}';
//    }
}