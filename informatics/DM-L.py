def find_partitions(n, minimum=1, current=[]):
    if n == 0:
        print(" ".join(map(str, current)))
        return

    for next_part in range(minimum, n + 1):
        find_partitions(n - next_part, next_part, current + [next_part])

N = int(input())

find_partitions(N)
