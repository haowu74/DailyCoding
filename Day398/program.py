class Node:
    def __init__(self, value, next=None) -> None:
        self.value = value
        self.next = next

def remove_kth_node_from_end(head, k):
    fast = head
    for i in range(k):
        fast = fast.next
    slow = head
    while fast.next is not None:
        fast = fast.next
        slow = slow.next
    slow.next = slow.next.next
