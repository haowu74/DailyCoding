import math
import argparse

maze =  [[False, False, False, False],
        [True, True, True, True],
        [False, False, False, False],
        [False, False, False, False]]

shortest = [list(map(lambda x: math.inf if x else -math.inf, r)) for r in maze]
explored = maze.copy()
width = len(maze[0])
height = len(maze)

def find_shortest_path(r, c, dest_r, dest_c):
    #print(r,c)
    explored[r][c] = True
    if r == dest_r and c == dest_c:
        shortest[r][c] = 0
    elif shortest[r][c] < 0:
        shortest[r][c] == 100
        shortest_neighbour = math.inf
        if r > 0 and not explored[r - 1][c]:
            up = find_shortest_path(r - 1, c, dest_r, dest_c)
            shortest_neighbour = up if up < shortest_neighbour else shortest_neighbour
        if r < height - 1 and not explored[r + 1][c]:
            down = find_shortest_path(r + 1, c, dest_r, dest_c)
            shortest_neighbour = down if down < shortest_neighbour else shortest_neighbour
        if c > 0 and not explored[r][c - 1]:
            left = find_shortest_path(r, c - 1, dest_r, dest_c)
            shortest_neighbour = left if left < shortest_neighbour else shortest_neighbour
        if c < width - 1 and not explored[r][c + 1]:
            right = find_shortest_path(r, c + 1, dest_r, dest_c)
            shortest_neighbour = right if right < shortest_neighbour else shortest_neighbour
        shortest[r][c] = shortest_neighbour + 1
    explored[r][c] = False
    return shortest[r][c]



def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('pos', metavar='N', type=int, nargs='+')
    args = parser.parse_args()

    shortest_path = find_shortest_path(args.pos[0], args.pos[1], args.pos[2], args.pos[3])
    print('null' if math.inf == shortest_path else shortest_path)
    #print(find_shortest_path(3, 0, 0, 0))

if __name__ == '__main__':
    main()