import argparse

def palindromic(word):
    size = len(word)
    if size <= 1:
        return True, size
    if size == 2:
        return (True, 2) if word[0] == word[1] else (False, 1)
    l = 0
    if word[0] == word[size - 1]:
        r, l = palindromic(word[1:size-1])
        # Only used when the substring has to be continuous
        # if r:
        return True, l + 2
    r1, l1 = palindromic(word[0:size-1])
    r2, l2 = palindromic(word[1:size])

    # print(l, l1, l2)
    return False, max(l, l1, l2)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('inputs', metavar='N', type=str)
    args = parser.parse_args()
    word = args.inputs
    r, l = palindromic(word)
    print(l)

if __name__ == '__main__':
    main()