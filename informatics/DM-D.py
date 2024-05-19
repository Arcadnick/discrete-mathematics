def generate_strings(n, k):
    digits = [str(x) for x in range(10)] + [chr(x) for x in range(ord('a'), ord('z')+1)]
    characters = digits[:k]
    
    def generate(current):
        if len(current) == n:
            print("".join(current))
        else:
            for char in characters[::-1]:
                generate(current + [char])

    generate([])


n, k = map(int, input().strip().split())
generate_strings(n, k)
