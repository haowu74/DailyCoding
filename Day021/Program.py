class interval:
    def __init__(self, start, end) -> None:
        self.start = start
        self.end = end


def main():
    intervals = [interval(30, 75), interval(75, 80), interval(80, 100)]

    starts = sorted(intervals, key=lambda x: x.start)
    sorted_starts = list(map(lambda x: x.start, starts))
    # for sorted_start in sorted_starts:
    #     print(sorted_start)

    ends = sorted(intervals, key=lambda x: x.end)
    sorted_ends = list(map(lambda x: x.end, ends))
    # for sorted_end in sorted_ends:
    #     print(sorted_end)
        
    max_overlap = 0
    overlap = 0
    end_index = 0
    for start_index in range(1, len(intervals)):
        while sorted_starts[start_index] >= sorted_ends[end_index]:
            overlap -= 1
            end_index += 1
        overlap += 1
        max_overlap = overlap if overlap > max_overlap else max_overlap

    print(max_overlap)


if __name__ == '__main__':
    main()