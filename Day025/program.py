import argparse

def match(s, p):
    if len(p) == 0:
        return len(s) == 0
    first_match = len(s) > 0 and (p[0] == s[0] or p[0] == '.')
    
    if len(p) >= 2 and p[1] == '*':
        return match(s, p[2:]) or (first_match and match(s[1:], p))
    else:
        return first_match and match(s[1:], p[1:])

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('inputs', metavar='N', type=str, nargs='+')
    args = parser.parse_args()
    re = args.inputs[0]
    word = args.inputs[1]
    print(match(word, re))

if __name__ == '__main__':
    main()