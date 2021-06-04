# sorted by start time
# pick the one with the earliest start time
# Find the ones overlapping with the first one
# Recursively call the same procedure until the end, and compare the candidates to get the largest set

buffer = {}

class interval:
    def __init__(self, start, end) -> None:
        self.start = start
        self.end = end

def find_no_overlapping_sets(sorted_intervals, index):
    if index in buffer:
        return buffer[index]
    if index == len(sorted_intervals):
        buffer[index] = [[]]
        return [[]]
    if index == len(sorted_intervals) - 1:
        buffer[index] = [[index]]
        return [[index]]
    non_overlapped = sorted((filter(lambda i: i.start >= sorted_intervals[index].end, sorted_intervals[index+1:])), key=lambda i: i.start)
    if len(non_overlapped) > 0:
        n = sorted_intervals.index(non_overlapped[0])
    else:
        n = len(sorted_intervals)
    candidates = []
    # print(index, n)
    for i in range(index+1, n):
        candidate = find_no_overlapping_sets(sorted_intervals, i)
        if len(candidate) > 0:
            for c in candidate:
                candidates.append(c)
    for i in range(n, len(sorted_intervals)):
        candidate = find_no_overlapping_sets(sorted_intervals, i)
        if len(candidate) > 0:
            for c in candidate:
                l = [index] + c
                candidates.append(l)
    buffer[index] = candidates
    return candidates

def main():
    intervals = [
        interval(0, 6),
        interval(1, 4),
        interval(3, 5),
        interval(3, 8),
        interval(4, 7),
        interval(5, 9),
        interval(6, 10),
        interval(8, 11),
        interval(8, 9),
        interval(9, 10)
        ]

    sorted_intervals = sorted(intervals, key=lambda i: i.start)
    candidates = sorted(find_no_overlapping_sets(sorted_intervals, 0), key=lambda i: len(i))
    for i in candidates[-1]:
        print(f"({intervals[i].start}, {intervals[i].end})")
    # for i in candidates:
    #     for j in i:
    #         print(f"({intervals[j].start}, {intervals[j].end})")
    #     print("---------------")

if __name__ == '__main__':
    main()