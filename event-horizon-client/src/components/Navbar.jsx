import { Calendar } from 'lucide-react';
import { motion } from 'framer-motion';

export default function Navbar() {
  return (
    <motion.nav 
      initial={{ y: -50, opacity: 0 }}
      animate={{ y: 0, opacity: 1 }}
      className="glass-panel" 
      style={{ 
        display: 'flex', padding: '1rem 2rem', alignItems: 'center', 
        justifyContent: 'space-between', marginBottom: '2rem' 
      }}>
      
      <div style={{ display: 'flex', alignItems: 'center', gap: '0.75rem' }}>
        <Calendar size={28} color="var(--accent-color)" />
        <h1 style={{ fontSize: '1.5rem', fontWeight: '800', letterSpacing: '-0.5px' }}>
          Event Horizon
        </h1>
      </div>
      
      <div>
        <motion.button 
          whileHover={{ scale: 1.05, backgroundColor: 'var(--accent-hover)' }} 
          whileTap={{ scale: 0.95 }} 
          style={{ 
            background: 'var(--accent-color)', color: 'white', border: 'none', 
            padding: '0.5rem 1.25rem', borderRadius: '8px', cursor: 'pointer', 
            fontWeight: '600', transition: 'background-color 0.2s' 
          }}>
          Create Event
        </motion.button>
      </div>
    </motion.nav>
  );
}
