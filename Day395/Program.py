import argparse

def one_hot(s):
    result = 0
    for ch in s:
        result += 1 << ord(ch) - ord('a')
    return result

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('words', metavar='N', type=str, nargs='+')
    args = parser.parse_args()

    groups = dict()

    for word in args.words:
        v = one_hot(word)
        if v in groups.keys():
            groups[v].append(word)
        else:
            groups[v] = [word]

    for k, v in groups.items():
        print(v)


if __name__ == '__main__':
    main()