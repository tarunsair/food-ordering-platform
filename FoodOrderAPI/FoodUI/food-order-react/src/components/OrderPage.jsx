import { useState } from "react";
import API from "../api/api";

export default function OrderPage({ cart, onDecrease }) {
  const [name, setName] = useState("");

  const total = cart.reduce(
    (sum, item) => sum + item.price * item.quantity,
    0
  );

  const placeOrder = () => {
    const order = {
      guestName: name,
      tokenNumber: Math.floor(Math.random() * 1000).toString(),
      totalAmount: total,
      orderItems: cart.map(i => ({
        menuItemId: i.id,
        quantity: i.quantity,
        totalPrice: i.price * i.quantity
      }))
    };

    API.post("/orders", order)
      .then(() => alert("Order placed!"));
  };

  return (
    <div className="w-80 bg-gray-100 p-4 rounded-xl shadow">
      <h2 className="text-xl font-bold mb-4">Cart</h2>

      {cart.map(item => (
        <div key={item.id} className="mb-3 border-b pb-2">
          <div className="font-semibold">{item.name}</div>

          <div className="flex justify-between items-center">
            <span>
              ${item.price} x {item.quantity}
            </span>

            <button
              onClick={() => onDecrease(item.id)}
              className="bg-red-500 text-white px-2 rounded"
            >
              -
            </button>
          </div>
        </div>
      ))}

      <h3 className="font-bold mt-4">Total: ${total.toFixed(2)}</h3>

      <input
        className="w-full mt-2 p-2 border rounded"
        placeholder="Guest Name"
        value={name}
        onChange={e => setName(e.target.value)}
      />

      <button
        onClick={placeOrder}
        className="w-full mt-3 bg-blue-600 text-white p-2 rounded"
      >
        Place Order 🚀
      </button>
    </div>
  );
}