import { useEffect, useState } from "react";
import API from "../api/api";

export default function CategoryList({ onSelect }) {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    API.get("/categories")
      .then(res => setCategories(res.data));
  }, []);

  return (
    <div className="w-60 bg-gray-100 p-4 rounded-xl shadow">
      <h2 className="text-xl font-bold mb-4">Categories</h2>

      {categories.map(c => (
        <div
          key={c.id}
          onClick={() => onSelect(c.id)}
          className="p-2 mb-2 bg-white rounded cursor-pointer hover:bg-blue-200"
        >
          {c.name}
        </div>
      ))}
    </div>
  );
}