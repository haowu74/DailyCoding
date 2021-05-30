words = {'quick', 'brown', 'the', 'fox', 'bed', 'bath', 'bedbath', 'and', 'beyond'}
sentence1 = 'thequickbrownfox'
sentence2 = 'bedbathandbeyond'

def find_words(sentence):
    results = []
    if len(sentence) == 0:
        yield [], True
        return
    found = False
    for i in range(len(sentence)):
        if sentence[:i+1] in words:
            for x, y in find_words(sentence[i+1:]):
                if y == True:
                    found = True
                    yield [sentence[:i+1]] + x, True
    if found == False:
        yield [], False
        return

def main():
    for s, v in find_words(sentence2):
        print(s)


if __name__ == '__main__':
    main()