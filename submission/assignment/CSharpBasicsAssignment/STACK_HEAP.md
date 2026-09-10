Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };

```text

STACK                              HEAP
┌──────────────────┐              ┌─────────────────────────┐
│ o1               │              │ Order Object            │
│ Address: 0x100   │─────────────►│ Address: 0x100          │
└──────────────────┘              │                         │
                                  │ OrderId      = 1        │
                                  │ CustomerName = "Ali"    │
                                  │ IsPaid       = false    │
                                  │ ...other fields...      │
                                  └─────────────────────────┘
```

o1 stores a reference to the Order object created on the heap

------------------------------------------------------

Order o2 = o1;

```text

STACK                              HEAP
┌──────────────────┐              ┌─────────────────────────┐
│ o1               │──┐           │ Order Object            │
│ Address: 0x100   │  │           │ Address: 0x100          │
└──────────────────┘  │           │                         │
                      ├──────────►│ OrderId      = 1        │
┌──────────────────┐  │           │ CustomerName = "Ali"    │
│ o2               │──┘           │ IsPaid       = false    │
│ Address: 0x100   │              │ ...other fields...      │
└──────────────────┘              └─────────────────────────┘

```

o2 = o1 copies the reference, so both variables point to the same heap object


-------------------------------------------------------

o2.IsPaid = true;

```text

STACK                              HEAP
┌──────────────────┐              ┌─────────────────────────┐
│ o1               │──┐           │ Order Object            │
│ Address: 0x100   │  │           │ Address: 0x100          │
└──────────────────┘  │           │                         │
                      ├──────────►│ OrderId      = 1        │
┌──────────────────┐  │           │ CustomerName = "Ali"    │
│ o2               │──┘           │ IsPaid       = true     │
│ Address: 0x100   │              │ ...other fields...      │
└──────────────────┘              └─────────────────────────┘
```

o2.IsPaid = true updates the shared Order object on the heap, so the change is visible through both o1 and o2.

--------------------------------------------------------

# What would be different with structs?

If Order were a struct, assigning o2 = o1 would copy the entire value instead of copying a reference.
Therefore, o1 and o2 would contain independent copies, so changing o2.IsPaid would not change o1.IsPaid.