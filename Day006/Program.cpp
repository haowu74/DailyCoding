#include <iostream>

class Node
{
    public:
        Node* last();
        std::string value;
        Node* both;
        Node(std::string value);
        void add(Node* node);
        Node* get(int index);
};

Node::Node(std::string value)
{
    this->value = value;
    this->both = nullptr;
}

Node* Node::last()
{
    Node* next;
    Node* current = this;
    Node* prev = nullptr;
    do
    {
        next = reinterpret_cast<Node*>(reinterpret_cast<uintptr_t>(current->both) ^ reinterpret_cast<uintptr_t>(prev));
        // std::cout<<next<<"\n";
        if(next != nullptr)
        {
            prev = current;
            current = next;
        }
    } while (next != nullptr);
    return current;
}

void Node::add(Node* node)
{
    Node* last = this->last();
    node->both = last;
    last->both = reinterpret_cast<Node*>(reinterpret_cast<uintptr_t>(last->both) ^ reinterpret_cast<uintptr_t>(node));
}

Node* Node::get(int index)
{
    Node* prev;
    Node* next;
    Node* current;
    for(int i = 0; i <= index; i++)
    {
        if(i == 0)
        {
            prev = 0;
            current = this;
            next = reinterpret_cast<Node*>(reinterpret_cast<uintptr_t>(current->both) ^ reinterpret_cast<uintptr_t>(prev));
        }
        else
        {
            prev = current;
            current = next;
            next = reinterpret_cast<Node*>(reinterpret_cast<uintptr_t>(current->both) ^ reinterpret_cast<uintptr_t>(prev));
            if(current == nullptr)
            {
                break;
            }
        }
    }
    return current;
}

int main()
{
    Node* node = new Node("1");
    node->add(new Node("2"));
    node->add(new Node("3"));
    node->add(new Node("4"));
    // std::cout<< node->last()->value<<"\n";
    std::cout<<node->get(0)->value<< "\n";
    std::cout<<node->get(1)->value<< "\n";
    std::cout<<node->get(2)->value<< "\n";
    std::cout<<node->get(3)->value<< "\n";
    return 0;
}