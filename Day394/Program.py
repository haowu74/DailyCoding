import argparse

class node:
    def __init__(self, value, left=None, right=None) -> None:
        self.value = value
        self.left = left
        self.right = right

def build_node(index, numbers):
    size = len(numbers)
    value = numbers[index]
    right = None if index * 2 + 2 >= size else build_node(index * 2 + 2, numbers)
    left = None if index * 2 + 1 >= size else build_node(index * 2 + 1, numbers)
    return node(value, left, right)

def is_leaf(node):
    return node.left == None and node.right == None

def search_path(node, value, carry_over=0):
    if node == None:
        return False
    sum = node.value + carry_over
    #print(sum)
    if is_leaf(node):
        return sum == value
    else:
        return search_path(node.left, value, sum) or search_path(node.right, value, sum)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('values', metavar='N', type=int, nargs='+')
    args = parser.parse_args()

    root = build_node(0, args.values[:-1])
    value = args.values[-1]
    print(search_path(root, value))


if __name__ == '__main__':
    main()