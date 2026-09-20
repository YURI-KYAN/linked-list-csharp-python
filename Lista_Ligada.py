class No:
    def __init__(self, valor):
        self.valor = valor
        self.proximo = None

class ListaLigada:
    def __init__(self):
        self.cabeca = None

    def inserir_inicio(self, valor):
        novo = No(valor)
        novo.proximo = self.cabeca
        self.cabeca = novo

    def inserir_fim(self, valor):
        novo = No(valor)
        if not self.cabeca:
            self.cabeca = novo
            return
        atual = self.cabeca
        while atual.proximo:
            atual = atual.proximo
        atual.proximo = novo

    def remover(self, valor):
        if not self.cabeca:
            return False
        if self.cabeca.valor == valor:
            self.cabeca = self.cabeca.proximo
            return True
        atual = self.cabeca
        while atual.proximo and atual.proximo.valor != valor:
            atual = atual.proximo
        if atual.proximo:
            atual.proximo = atual.proximo.proximo
            return True
        return False

    def buscar(self, valor):
        atual = self.cabeca
        while atual:
            if atual.valor == valor:
                return True
            atual = atual.proximo
        return False

    def exibir(self):
        valores = []
        atual = self.cabeca
        while atual:
            valores.append(str(atual.valor))
            atual = atual.proximo
        print(" -> ".join(valores) + " -> None")

# Teste
if __name__ == "__main__":
    lista = ListaLigada()
    lista.inserir_fim(10)
    lista.inserir_fim(20)
    lista.inserir_inicio(5)
    lista.exibir()  # 5 -> 10 -> 20 -> None
    print("Buscar 10:", lista.buscar(10))
    lista.remover(10)
    lista.exibir()
