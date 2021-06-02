import argparse

def match(re, word):
    if len(re) == 0:
        return len(word) == 0
    else:
        if re[0] == '.':
            if (len(word) == 0):
                return False
            return match(re[1:], word[1:])
        elif re[0] == '*':
            if len(re) == 1:
                return True
            matching = False
            for i in range(len(word)):
                matching = matching or match(re[1:], word[i:])
            return matching
        else:
            if re[0] != word[0]:
                return False
            else:
                return match(re[1:], word[1:])

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('inputs', metavar='N', type=str, nargs='+')
    args = parser.parse_args()
    re = args.inputs[0]
    word = args.inputs[1]
    print(match(re, word))

if __name__ == '__main__':
    main()