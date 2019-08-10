//https://www.codewars.com/kata/5ac698cdd325ad18a3000170
select f.name, SUM(f.won) as won, SUM(f.lost) as lost from
fighters as f join winning_moves as w
on f.move_id = w.id
where w.move not in ('Hadoken', 'Shouoken', 'Kikoken')
group by f.name
order by won desc
limit 6
