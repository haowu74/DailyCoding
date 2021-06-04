class Node:
    def __init__(self, value, next=None):
        self.value = value
        self.next = next

    def __str__(self):
        current_node = self
        result = []
        while current_node:
            result.append(current_node.value)
            current_node = current_node.next
        return str(result)

def remove_kth_node_from_end(head, k):
    fast = head
    for i in range(k):
        fast = fast.next
    slow = head
    while fast.next is not None:
        fast = fast.next
        slow = slow.next
    slow.next = slow.next.next

def main():
    head = Node(1, Node(2, Node(3, Node(4, Node(5)))))
    print(head)
    remove_kth_node_from_end(head, 4)
    print(head)

if __name__ == "__main__":
    main()