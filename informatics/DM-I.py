def generate(current_sequence, start, length):
        if length == 0:
            sequences.append(current_sequence[:])
            return

        for i in range(start, 0, -1):
            current_sequence.append(i)
            generate(current_sequence, i - 1, length - 1)
            current_sequence.pop()

n, k = map(int, input().split())
sequences = []

generate([], n, k)

for i in range(len(sequences) - 1, -1, -1):
    print(*sequences[i])