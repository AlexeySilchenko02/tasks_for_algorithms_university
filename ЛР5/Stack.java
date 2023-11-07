public class Stack {
    private static final int DEFSIZE = 500;
    private Node[] array;
    private int head;

    public Stack(){
        array = new Node[DEFSIZE];
        head = 0;
    }

    public final void push(Node val) {
        array[head++] = val;
    }

    public final Node pop() {
        return array[--head];
    }

    public final Node top() {
        return array[head - 1];
    }

    public Boolean isEmpty() {
        return head == 0;
    }
}