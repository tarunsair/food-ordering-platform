import { useEffect, useState } from "react";
import API from "../../api/api";

export default function MenuForm({ onSuccess }) {
  const [categories, setCategories] = useState([]);
  const [form, setForm] = useState({
    name: "",
    description: "",
    price: 0,
    imageUrl: "",
    categoryId: 0
  });

  useEffect(() => {
    API.get("/categories").then(res => setCategories(res.data));
  }, []);

  const handleSubmit = () => {
    API.post("/menuitems", form)
      .then(() => {
        alert("Menu item added!");
        onSuccess();
      });
  };

  return (
    <div className="mb-4 bg-white p-4 rounded shadow">
      <h2 className="font-bold mb-2">Add Menu Item</h2>

      <input placeholder="Name"
        onChange={e => setForm({ ...form, name: e.target.value })}
        className="border p-2 mr-2" />

      <input placeholder="Price"
        type="number"
        onChange={e => setForm({ ...form, price: +e.target.value })}
        className="border p-2 mr-2" />

      <input placeholder="Image URL"
        onChange={e => setForm({ ...form, imageUrl: e.target.value })}
        className="border p-2 mr-2" />

      <select
        onChange={e => setForm({ ...form, categoryId: +e.target.value })}
        className="border p-2 mr-2"
      >
        <option>Select Category</option>
        {categories.map(c => (
          <option key={c.id} value={c.id}>{c.name}</option>
        ))}
      </select>

      <button
        onClick={handleSubmit}
        className="bg-green-500 text-white px-3 py-1 rounded"
      >
        Add
      </button>
    </div>
  );
}