import math
import argparse

# It is basically calculating the sum of cost[i][j] in the matrix of N x K,
# which means the cost of ith house using jth color.
# Each house has one color, and no neighbouring houses have the same color. 

def paint_house(cost):
    n = len(cost)
    k = len(cost[0])
    solution = [[0] * k]
    for r in range(n):
        min_cost = []
        for c in range(k):
            min_cost.append(min(solution[r][i] for i in range(k) if i != c) + cost[r][c])
        solution.append(min_cost)    
    return min(solution[-1])


def main():
    # parser = argparse.ArgumentParser()
    # parser.add_argument('-N', type=int)
    # parser.add_argument('-K', type=int)
    # args = parser.parse_args()
    cost = [[3,4,5,9,3],[7,7,5,9,1],[8,8,3,7,5],[1,2,7,4,9],[4,3,4,2,6],[5,5,4,9,9]]
    print(paint_house(cost))

if __name__ == '__main__':
    main()