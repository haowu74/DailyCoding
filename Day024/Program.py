import argparse

class node:
    def __init__(self, value, left=None, right=None, parent=None) -> None:
        self.value = value
        self.left = left
        self.right = right
        self.parent = parent
        self.locked = False
        if left == None and right == None:
            self.frozen = False
        elif left == None:
            self.frozen = self.right.locked
        elif right == None:
            self.frozen = self.left.locked
        else:
            self.frozen = self.left.locked or self.right.locked

    def freeze(self):
        self.frozen = True
        if self.parent != None:
            self.parent.freeze()

    def unfreeze(self):
        if self.left == None and self.right == None:
            self.frozen = False
        elif self.left == None:
            self.frozen = self.right.locked
        elif self.right == None:
            self.frozen = self.left.locked
        else:
            self.frozen = self.left.locked or self.right.locked

        if not self.frozen:
            if self.parent != None:
                self.parent.unfreeze()    

    def is_locked(self):
        return self.locked

    def lock(self):
        if not self.frozen:
            self.locked = True
            if self.parent != None:
                self.parent.freeze()

    def unlock(self):
        if not self.frozen:
            self.locked = False
            if self.parent != None:
                self.parent.unfreeze()

def build_node(index, numbers):
    size = len(numbers)
    value = numbers[index]
    right = None if index * 2 + 2 >= size else build_node(index * 2 + 2, numbers)
    left = None if index * 2 + 1 >= size else build_node(index * 2 + 1, numbers)
    parent = None if index == 0 else (index - 1) // 2
    return node(value, left, right, parent)

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('values', metavar='N', type=int, nargs='+')
    args = parser.parse_args()

    root = build_node(0, args.values)

if __name__ == '__main__':
    main()