import argparse

def is_balanced(brackets):
    buffer = []
    for b in brackets:
        if b == '(' or b == '[' or b == '{':
            buffer.append(b)
        elif b == ')' or b == ']' or b == '}':
            if len(buffer) == 0:
                return False
            top = buffer.pop(-1)
            if (b == ')' and top != '(') or (b == ']' and top != '[') or (b == '}' and top != '{'):
                return False
    return len(buffer) == 0


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('brackets', type=str)
    args = parser.parse_args()
    brackets = args.brackets
    print(is_balanced(brackets))

if __name__ == '__main__':
    main()